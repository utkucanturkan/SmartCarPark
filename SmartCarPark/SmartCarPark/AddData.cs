using SmartCarPark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartCarPark.ManagementForm;

namespace SmartCarPark
{
    public partial class AddData : Form
    {
        public ManagementDataType _dataType { get; set; }

        public AddData()
        {
            InitializeComponent();
        }

        private void AddData_Load(object sender, EventArgs e)
        {
            pnlControls.Controls.Clear();

                UserControl uc = null;
                switch (_dataType)
                {
                    case ManagementDataType.Apartment:
                        uControlAddApartment ucA = new uControlAddApartment();
                        uc = ucA;
                        this.Text = "Add Apartment";
                    break;

                    case ManagementDataType.Car:
                    uControlAddCar ucC = new uControlAddCar();
                        uc = ucC;
                        this.Text = "Add Car";
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
