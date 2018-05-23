using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCarPark
{
    public partial class MainPage : Form
    {
        public enum ImageProcessType
        {
            Live,
            File
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void tsBtn_Click(object sender, EventArgs e)
        {
            ImageProcessType sType = ImageProcessType.File;
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Text == "Live")
            {
                sType = ImageProcessType.Live;
            }
            PlateRecognitionSystemForm f = new PlateRecognitionSystemForm { imageProcessType = sType };
            ShowForm(f);
        }

        private void tsApartmentManagementBtn_Click(object sender, EventArgs e)
        {
            ManagementForm frm = new ManagementForm { _dataType = ManagementForm.ManagementDataType.Apartment };
            ShowForm(frm);
        }

        private void ShowForm(Form frm)
        {
            CloseChildForms();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void CloseChildForms()
        {
            foreach (Form frm in MdiChildren)
            {
                frm.Close();
                frm.Dispose();
            }
        }
    }
}
