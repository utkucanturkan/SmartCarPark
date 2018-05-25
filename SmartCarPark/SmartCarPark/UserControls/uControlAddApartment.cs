using SmartCarPark.Models;
using System;
using System.Windows.Forms;

namespace SmartCarPark
{
    public partial class uControlAddApartment : UserControl
    {
        public uControlAddApartment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Apartment.Add(new Apartment
            {
                LastName = txtOwner.Text,
                No = txtApartmentNo.Text
            });

            this.ParentForm.Close();
        }
    }
}
