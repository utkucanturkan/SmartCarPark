using SmartCarPark.Models;
using System;
using System.Windows.Forms;

namespace SmartCarPark
{
    public partial class uControlEditApartment : UserControl
    {
        public uControlEditApartment()
        {
            InitializeComponent();
        }

        public Apartment apartment { get; set; }

        private void uControlEditApartment_Load(object sender, EventArgs e)
        {
            if (apartment != null)
            {
                FillCars();
                txtApartmentNo.Text = apartment.No;
                txtOwner.Text = apartment.LastName;
            }
        }

        private void FillCars()
        {
            dgCars.DataSource = Apartment.GetCars(apartment.Id);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Apartment.Update(new Apartment
            {
                Id = apartment.Id,
                LastName = txtOwner.Text,
                No = txtApartmentNo.Text
            });
            this.ParentForm.Close();
        }

    }
}
