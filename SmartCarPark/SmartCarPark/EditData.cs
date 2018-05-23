using SmartCarPark.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using static SmartCarPark.ManagementForm;

namespace SmartCarPark
{
    public partial class EditData : Form
    {
        public EditData()
        {
            InitializeComponent();
        }

        public ManagementDataType _dataType { get; set; }
        public int _pk { get; set; }

        private void EditData_Load(object sender, EventArgs e)
        {
            pnlControls.Controls.Clear();
            if (_pk > 0)
            {
                UserControl uc = null;
                switch (_dataType)
                {
                    case ManagementDataType.Apartment:
                        uControlEditApartment ucA = new uControlEditApartment();
                        ucA.apartment = Apartment.Get(_pk);
                        uc = ucA;
                        this.Text = "Edit Apartment";
                        break;
                    case ManagementDataType.Car:
                        uControlEditCar ucC = new uControlEditCar();
                        ucC.car = Car.Get(_pk);
                        uc = ucC;
                        this.Text = "Edit Car";
                        break;
                }
                if (uc != null)
                {
                    uc.Location = new Point(10, 10);
                    pnlControls.Controls.Add(uc);
                }
            }
        }
    }
}
