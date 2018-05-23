using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using SmartCarPark.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static SmartCarPark.MainPage;

namespace SmartCarPark
{
    public partial class PlateRecognitionSystemForm : Form
    {
        private PlateFinder PlateFinder;
        private FilterInfoCollection webcam; // webcam isminde tanımladığımız değişken bilgisayara kaç kamera bağlıysa onları tutan bir dizi. 
        private VideoCaptureDevice cam; // cam ise bizim kullanacağımız aygıt.

        public ImageProcessType imageProcessType { get; set; }
        private string photopath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug\", "") + @"files\p-photo.jpeg";
        private bool isDetected = false;
        private Bitmap _livePhoto = null;
        Car c = null;

        public PlateRecognitionSystemForm()
        {
            InitializeComponent();
        }

        #region GetImageAndProcess
        public void GetImageAndProcess(ImageProcessType sType)
        {
            string _imgpath = photopath;
            Mat _img = null;
            switch (sType)
            {
                case ImageProcessType.Live:
                    Image<Bgr, Byte> new_img = new Image<Bgr, Byte>(_livePhoto);
                    _img = new_img.Mat;
                    break;
                case ImageProcessType.File:
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Title = "Select a Image";

                    dialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        _imgpath = dialog.FileName;
                        pbOrginal.ImageLocation = _imgpath;
                        _img = CvInvoke.Imread(_imgpath, LoadImageType.Color);
                    }
                    break;
                default:
                    MessageBox.Show("An unexpected error has occurred!");
                    break;
            }

            try
            {
                if (_img != null)
                {
                    ImageProcess(_img);
                }
            }
            catch (Exception ex)
            {
                _timer.Enabled = false;
                MessageBox.Show(ex.Message + " !");
            }
        }
        #endregion

        #region ImageProcess
        private void ImageProcess(Mat selectedPicture)
        {
            Stopwatch ProcessTime = Stopwatch.StartNew(); //yapılan işlem süresi tutmak için 
            UMat UMatImage = selectedPicture.ToUMat(AccessType.ReadWrite);
            List<IInputOutputArray> plakaGoruntuListesi = new List<IInputOutputArray>();
            List<IInputOutputArray> filtrelenmisPlakaGoruntuListesi = new List<IInputOutputArray>();
            List<RotatedRect> lisansKutusuListesi = new List<RotatedRect>();
            List<string> DetectedPlate = PlateFinder.DetectPlate(UMatImage, plakaGoruntuListesi, filtrelenmisPlakaGoruntuListesi, lisansKutusuListesi);
            ProcessTime.Stop();

            Bitmap objBitmapgri = new Bitmap(PlateFinder.GrayView, new Size(250, 250));
            Bitmap objBitmapcanny = new Bitmap(PlateFinder.CannyView, new Size(250, 250));
            pbGrey.Image = objBitmapgri;    //gri formatlı bitmapi ekranda gösterdim.
            pbCanny.Image = objBitmapcanny;  //kenar bulunmuş bitmapi ekranda gösterdim.

            for (int i = 0; i < DetectedPlate.Count; i++)
            {
                Mat songoruntu = new Mat();
                CvInvoke.VConcat(plakaGoruntuListesi[i], filtrelenmisPlakaGoruntuListesi[i], songoruntu);   //dikey olarak verilen iki göruntuyu birleştirmek için

                PlateResultImage(String.Format("{0}", DetectedPlate[i]), songoruntu, DetectedPlate.First(), ProcessTime.Elapsed.TotalSeconds);

                PointF[] koselerF = lisansKutusuListesi[i].GetVertices();
                Point[] koseler = Array.ConvertAll(koselerF, Point.Round);
                using (VectorOfPoint pts = new VectorOfPoint(koseler))
                    CvInvoke.Polylines(selectedPicture, pts, true, new Bgr(Color.Red).MCvScalar, 2);
            }
        }
        #endregion

        private void PlateResultImage(string labelText, IImage image, string plateText, double processTime)
        {
            pnlResult.Controls.Clear();
            Point baslangicNoktasi = new Point(10, 10); // plakafotoğraflar için başlangıç noktası

            Label label = new Label();
            label.Text = labelText;
            label.Width = 250;
            label.Height = 30;
            label.Font = new Font("Arial", 20);
            label.Font = new Font(label.Font, FontStyle.Bold);
            label.ForeColor = Color.Red;
            label.Location = baslangicNoktasi;
            baslangicNoktasi.Y += label.Height;
            pnlResult.Controls.Add(label);

            ImageBox box = new ImageBox();
            box.ClientSize = image.Size;
            box.Image = image;
            box.Location = baslangicNoktasi;
            baslangicNoktasi.Y += box.Height + 10;
            pnlResult.Controls.Add(box);

            c = Car.isValidCar(labelText);  // Okunan plaka kontrol ediliyor.

            if (c != null)  // Sistemde mevcut olan plaka kapıyı açar
            {
                _timer.Enabled = false;

                lblProcessTime.Text = String.Format("Görüntü İşleme Süresi : {0} milisaniye", processTime);
                lblPlate.Text = plateText;
                lblSonuc.Text = "İşlem başarılı";
                lblPerson.Text = c.Apartment.LastName;
                //isDetected = true;

                runArdunio();
            }

        }

        private void runArdunio()
        {
            // System.IO.Ports.SerialPort.GetPortNames()[i]

            //
            // Ardunio ya isDetected degeri gönderilebilir
            //

            sPort.PortName = "COM8";

            if (!sPort.IsOpen)
                sPort.Open();

            sPort.Write("1");

            if (sPort.IsOpen)
                sPort.Close();
        }

        Timer _timer = new Timer() { Enabled = false };

        private void PlateRecognitionSystemForm_Load(object sender, EventArgs e)
        {
            PlateFinder = new PlateFinder();

            //for (int i = 0; i < System.IO.Ports.SerialPort.GetPortNames().Length; i++)
            //{
            //    comboBox1.Items.Add(System.IO.Ports.SerialPort.GetPortNames()[i]);
            //}

            if (imageProcessType == ImageProcessType.Live)
            {
                _timer.Tick += _timer_Tick;
                RunCameraAndGetLiveImage();
            }
            else
            {
                GetImageAndProcess(imageProcessType);
            }
        }

        // ----- File
        private void tsNewImageBtn_Click(object sender, EventArgs e)
        {
            if (imageProcessType == ImageProcessType.Live)
            {
                c = null;
                pnlResult.Controls.Clear();
                lblPlate.Text = lblSonuc.Text = lblPerson.Text = "xxx";
                lblProcessTime.Text = "Görüntü İşleme Süresi :";
                this.OnLoad(null);
            }
            else
            {
                GetImageAndProcess(imageProcessType);
            }

        }

        // ----- Live
        private void RunCameraAndGetLiveImage()
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            StopCam();
            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            // cam.VideoResolution = cam.VideoCapabilities[3];

            if (cam != null)
            {
                if (cam.IsRunning == false)
                {
                    cam.Start(); //kamerayı başlatıyoruz.
                }
            }

            //yüklenirken görüntü akışı alınmaya başlanıyor
            _timer.Interval = 200;  //timer'in tick olayının çalışması için gereken süre (ms)
            _timer.Enabled = true;  //timer varsayılan olarak devre dışı halde olur, program açılışında etkindeştiriyoruz
        }

        private void Cam_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            // Timer
            //Bitmap bit = (Bitmap)eventArgs.Frame.Clone(); // kameradan alınan görüntüyü picturebox a atıyoruz.
            _livePhoto = (Bitmap)eventArgs.Frame.Clone();
            pbOrginal.Image = _livePhoto;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (pbOrginal.Image != null)
            {
                GetImageAndProcess(imageProcessType);
            }
        }

        //public void ListWebCams()
        //{
        //    webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice); //webcam dizisine mevcut kameraları dolduruyoruz.
        //    foreach (FilterInfo videocapturedevice in webcam)
        //    {
        //        //cmbCameraList.Items.Add(videocapturedevice.Name); //kameraları combobox a dolduruyoruz.
        //    }
        //    StopCam();
        //}

        public void StopCam()
        {
            if (cam != null)
            {
                if (cam.IsRunning)
                {
                    cam.Stop();
                }
            }
        }

        private void PlateRecognitionSystemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imageProcessType == ImageProcessType.Live)
            {
                StopCam();
            }
        }
    }
}
