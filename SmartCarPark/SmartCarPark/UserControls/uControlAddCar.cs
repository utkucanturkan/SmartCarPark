using SmartCarPark.Models;
using System;
using System.Windows.Forms;

namespace SmartCarPark
{
    public partial class uControlAddCar : UserControl
    {
        private Car car;
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
            car.Add(new Car
            {
                Plate = txtPlate.Text,
                ApartmentNo = Convert.ToInt16(cmbApartments.SelectedValue)
            });
            this.ParentForm.Close();
        }
    }
}
