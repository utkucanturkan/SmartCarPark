using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using System.Windows.Forms;

namespace SmartCarPark
{
    public class PlateFinder
    {
        private Tesseract OCR;
        public Bitmap GrayView, CannyView;
        public String CityCode = string.Empty;
        public String LetterGruop = string.Empty;
        public String NumberGroup = string.Empty;
        public Image<Bgr, Byte> ImageOriginalPublic;
        public int[,] Hierarchy;

        public PlateFinder()
        {           
            OCR = new Tesseract(string.Empty, "eng", OcrEngineMode.Default); //ocr ın okuma dili ve okumaModu ayarlama
            OCR.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPRSTUVYZ 0123456789");
        }

        #region DetectPlate
        public List<String> DetectPlate(IInputArray grnt, List<IInputOutputArray> PlateGoruntuListesi, List<IInputOutputArray> filtrelenmisPlateGoruntuListesi, List<RotatedRect> tespitEdilenPlateBolgeListesi)
        {
            List<String> Licences = new List<String>();
            using (Mat GrayFormat = new Mat())
            using (Mat CannyFormat = new Mat())

            using (VectorOfVectorOfPoint cevre = new VectorOfVectorOfPoint())
            {
                CvInvoke.CvtColor(grnt, GrayFormat, ColorConversion.Bgr2Gray);
                GrayView = GrayFormat.Bitmap;
                CvInvoke.Canny(GrayFormat, CannyFormat, 130, 10, 3, false);

                CannyView = CannyFormat.Bitmap;

                int[,] Hierarchy = CvInvoke.FindContourTree(CannyFormat, cevre, ChainApproxMethod.ChainApproxSimple);

                this.Hierarchy = Hierarchy;

                FindPlate(cevre, Hierarchy, 0, GrayFormat, CannyFormat, PlateGoruntuListesi, filtrelenmisPlateGoruntuListesi, tespitEdilenPlateBolgeListesi, Licences);
            }

            return Licences;
        }
        #endregion

        #region CharacterCount
        private static int CharacterCount(int[,] hierachy, int Index)
        {
            //ilk karekter
            Index = hierachy[Index, 2];
            if (Index < 0)
                return 0;

            int count = 1;
            while (hierachy[Index, 0] > 0)
            {
                count++;
                Index = hierachy[Index, 0];
            }
            return count;
        }
        #endregion

        #region FindPlate
        private void FindPlate(
       VectorOfVectorOfPoint cevreler, int[,] hiyerarsi, int idx, IInputArray gri, IInputArray cannykenar,
       List<IInputOutputArray> PlateGoruntuLisesi, List<IInputOutputArray> filtrelenmisPlateGoruntuListesi, List<RotatedRect> tespitEdilenPlateBolgesiListesi,
       List<String> licenses)
        {
            for (; idx >= 0; idx = hiyerarsi[idx, 0])
            {
                int karaktersayisi = CharacterCount(hiyerarsi, idx);

                if (karaktersayisi == 0) continue;

                using (VectorOfPoint cevre = cevreler[idx])
                {
                    if (CvInvoke.ContourArea(cevre) > 400)
                    {
                        if (karaktersayisi < 3)
                        {

                            FindPlate(cevreler, hiyerarsi, hiyerarsi[idx, 2], gri, cannykenar, PlateGoruntuLisesi,
                               filtrelenmisPlateGoruntuListesi, tespitEdilenPlateBolgesiListesi, licenses);
                            continue;
                        }

                        RotatedRect kutu = CvInvoke.MinAreaRect(cevre);

                        if (kutu.Angle < -45.0)
                        {
                            float tmp = kutu.Size.Width;
                            kutu.Size.Width = kutu.Size.Height;
                            kutu.Size.Height = tmp;
                            kutu.Angle += 90.0f;
                        }
                        else if (kutu.Angle > 45.0)
                        {
                            float tmp = kutu.Size.Width;
                            kutu.Size.Width = kutu.Size.Height;
                            kutu.Size.Height = tmp;
                            kutu.Angle -= 90.0f;
                        }

                        double enboyoran = (double)kutu.Size.Width / kutu.Size.Height;
                        if (!(3.0 < enboyoran && enboyoran < 10.0))

                        {

                            if (hiyerarsi[idx, 2] > 0)
                                FindPlate(cevreler, hiyerarsi, hiyerarsi[idx, 2], gri, cannykenar, PlateGoruntuLisesi,
                                   filtrelenmisPlateGoruntuListesi, tespitEdilenPlateBolgesiListesi, licenses);
                            continue;
                        }

                        using (UMat tmp1 = new UMat())
                        using (UMat tmp2 = new UMat())
                        {
                            PointF[] kutuKoseNokta = kutu.GetVertices(); // kutunun köşe noktalarını alır

                            PointF[] destCorners = new PointF[] {
                        new PointF(0, kutu.Size.Height - 1),
                        new PointF(0, 0),
                        new PointF(kutu.Size.Width - 1, 0),
                        new PointF(kutu.Size.Width - 1, kutu.Size.Height - 1)};

                            using (Mat rot = CvInvoke.GetAffineTransform(kutuKoseNokta, destCorners))
                            {
                                CvInvoke.WarpAffine(gri, tmp1, rot, Size.Round(kutu.Size));
                            }

                            Size yaklasikBoyut = new Size(240, 180); // yaklaşık boyut
                            double olcek = Math.Min(yaklasikBoyut.Width / kutu.Size.Width, yaklasikBoyut.Height / kutu.Size.Height);
                            Size newSize = new Size((int)Math.Round(kutu.Size.Width * olcek), (int)Math.Round(kutu.Size.Height * olcek));
                            CvInvoke.Resize(tmp1, tmp2, newSize, 0, 0, Inter.Cubic);


                            int edgePixelSize = 2;
                            Rectangle newRoi = new Rectangle(new Point(edgePixelSize, edgePixelSize),
                               tmp2.Size - new Size(2 * edgePixelSize, 2 * edgePixelSize));
                            UMat Plate = new UMat(tmp2, newRoi);

                            UMat filtrelenmisPlate = FilterPlate(Plate);

                            Tesseract.Character[] words;
                            StringBuilder strBuilder = new StringBuilder();
                            using (UMat tmp = filtrelenmisPlate.Clone())
                            {
                                OCR.Recognize(tmp);
                                words = OCR.GetCharacters();

                                if (words.Length == 0) continue;

                                for (int i = 0; i < words.Length; i++)
                                {
                                    strBuilder.Append(words[i].Text);
                                }
                            }

                            int sayac = 0;
                            int bosluk = 0;
                            for (int i = 0; i < strBuilder.Length; i++)
                            {
                                if (strBuilder[i].ToString() == "." || strBuilder[i].ToString() == "?" || strBuilder[i].ToString() == "*" || strBuilder[i].ToString() == "-")
                                    sayac++;

                                if (strBuilder[i].ToString() == " ")
                                    bosluk++;
                            }

                            if (strBuilder[0].ToString() == "E" || strBuilder[0].ToString() == "F" || strBuilder[0].ToString() == "I" || strBuilder[0].ToString() == "T")
                                strBuilder.Remove(0, 1);

                            if (sayac == 0 && strBuilder.Length >= 9 && bosluk <= 2)
                            {
                                string[] parcalar;

                                String asd = strBuilder.ToString();
                                parcalar = asd.Split(' ');
                                if (parcalar.Length == 3)
                                {
                                    CityCode = parcalar[0];
                                    LetterGruop = parcalar[1];
                                    NumberGroup = parcalar[2];
                                    if (CityCode.Length == 3)
                                        CityCode = CityCode.Remove(0, 1);

                                    CityCode = CityCode.Replace('B', '8');
                                    CityCode = CityCode.Replace('D', '0');
                                    CityCode = CityCode.Replace('G', '6');
                                    CityCode = CityCode.Replace('I', '1');
                                    CityCode = CityCode.Replace('O', '0');
                                    CityCode = CityCode.Replace('S', '5');
                                    CityCode = CityCode.Replace('Z', '2');
                                    CityCode = CityCode.Replace('L', '4');

                                    LetterGruop = LetterGruop.Replace('2', 'Z');
                                    LetterGruop = LetterGruop.Replace('0', 'D');
                                    LetterGruop = LetterGruop.Replace('5', 'S');
                                    LetterGruop = LetterGruop.Replace('6', 'G');
                                    LetterGruop = LetterGruop.Replace('8', 'B');
                                    LetterGruop = LetterGruop.Replace('1', 'I');

                                    NumberGroup = NumberGroup.Replace('B', '8');
                                    NumberGroup = NumberGroup.Replace('D', '0');
                                    NumberGroup = NumberGroup.Replace('G', '6');
                                    NumberGroup = NumberGroup.Replace('I', '1');
                                    NumberGroup = NumberGroup.Replace('O', '0');
                                    NumberGroup = NumberGroup.Replace('S', '5');
                                    NumberGroup = NumberGroup.Replace('Z', '2');
                                    NumberGroup = NumberGroup.Replace('A', '4');

                                    if (NumberGroup.Length == 5)
                                        NumberGroup = NumberGroup.Remove(4, 1);

                                    strBuilder.Remove(0, strBuilder.Length);
                                    strBuilder.Append(CityCode);
                                    strBuilder.Append(" ");
                                    strBuilder.Append(LetterGruop);
                                    strBuilder.Append(" ");
                                    strBuilder.Append(NumberGroup);
                                }

                                if (strBuilder.Length >= 7 && strBuilder.Length <= 10)
                                {
                                    licenses.Add(strBuilder.ToString());
                                    PlateGoruntuLisesi.Add(Plate);
                                    filtrelenmisPlateGoruntuListesi.Add(filtrelenmisPlate);
                                    tespitEdilenPlateBolgesiListesi.Add(kutu);
                                }
                            }

                        }
                    }
                }
            }
        }
        #endregion

        #region FilterPlate
        private static UMat FilterPlate(UMat Plate)
        {
            UMat thresh = new UMat();

            CvInvoke.Threshold(Plate, thresh, 120, 255, ThresholdType.BinaryInv);

            // kesilen Plate bölgesinin (ikili)iki renkten oluşan görüntüsü alınır
            // orjinal 120,255
            Size PlateBoyutu = Plate.Size;
            using (Mat PlateMaskesi = new Mat(PlateBoyutu.Height, PlateBoyutu.Width, DepthType.Cv8U, 1))
            // cv8u=byte
            using (Mat PlateCanny = new Mat())

            using (VectorOfVectorOfPoint cevreler = new VectorOfVectorOfPoint())
            {
                PlateMaskesi.SetTo(new MCvScalar(255.0));
                CvInvoke.Canny(Plate, PlateCanny, 100, 50);// 100,50 idi orjinal
                                                           // Platebolgesicanny = plateCanny.Bitmap;
                CvInvoke.FindContours(PlateCanny, cevreler, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                int count = cevreler.Size;
                for (int i = 1; i < count; i++)
                {
                    using (VectorOfPoint cevre = cevreler[i])
                    {

                        Rectangle dikdortgen = CvInvoke.BoundingRectangle(cevre);
                        if (dikdortgen.Height > (PlateBoyutu.Height >> 1))
                        {
                            dikdortgen.X -= 1; dikdortgen.Y -= 1; dikdortgen.Width += 2; dikdortgen.Height += 2;
                            Rectangle roi = new Rectangle(Point.Empty, Plate.Size);
                            dikdortgen.Intersect(roi);
                            CvInvoke.Rectangle(PlateMaskesi, dikdortgen, new MCvScalar(), -1);

                        }
                    }

                }

                thresh.SetTo(new MCvScalar(), PlateMaskesi);
            }

            CvInvoke.Erode(thresh, thresh, null, new Point(-1, -1), 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
            CvInvoke.Dilate(thresh, thresh, null, new Point(-1, -1), 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);

            return thresh;
        }
        #endregion

    }
}
