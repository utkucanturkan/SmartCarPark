using SmartCarPark.Models;
using System;
using System.Windows.Forms;

namespace SmartCarPark
{
    public partial class uControlEditCar : UserControl
    {
        public uControlEditCar()
        {
            InitializeComponent();
        }

        public Car car { get; set; }

        private void uControlEditCar_Load(object sender, EventArgs e)
        {
            FillApartments();
            if (car != null)
            {
                txtPlate.Text = car.Plate;
                cmbApartments.SelectedValue = car.ApartmentNo;
            }
            else
            {
                MessageBox.Show("Car is not exists");
            }
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
            car.Edit(car.Id, new Car { Plate = txtPlate.Text, ApartmentNo = ((ApartmentListModel)cmbApartments.SelectedItem).Id });
            this.ParentForm.Close();
        }
    }
}
