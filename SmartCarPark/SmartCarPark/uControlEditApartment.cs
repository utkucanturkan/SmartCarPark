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
            var model = new Apartment
            {
                Id=apartment.Id,
                LastName = txtOwner.Text,
                No = txtApartmentNo.Text
            };
            Apartment.Update(model);
            this.ParentForm.Close();
        }

    }
}
