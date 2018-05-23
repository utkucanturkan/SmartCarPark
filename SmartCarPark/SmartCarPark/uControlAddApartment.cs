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
    public partial class uControlAddApartment : UserControl
    {
        public uControlAddApartment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new Apartment
            {
                LastName = txtOwner.Text,
                No = txtApartmentNo.Text
            };
            Apartment.Add(model);

            this.ParentForm.Close();
        }
    }
}
