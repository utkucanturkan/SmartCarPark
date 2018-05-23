using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartCarPark.Models;

namespace SmartCarPark
{
    public partial class uControlAddCar : UserControl
    {
        Car car;
        public uControlAddCar()
        {
            InitializeComponent();
            car = new Car();
        }

        private void uControlAddCar_Load(object sender, EventArgs e)
        {
            FillApartments();
        }

        private void FillApartments()
        {
            cmbApartments.Items.Clear();
            cmbApartments.DataSource = Apartment.List();
            cmbApartments.DisplayMember = "No";
            cmbApartments.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new Car
            {
                Plate = txtPlate.Text,
                ApartmentNo = Convert.ToInt16(cmbApartments.SelectedValue)
            };
            car.Add(model);
            this.ParentForm.Close();
        }
    }
}
