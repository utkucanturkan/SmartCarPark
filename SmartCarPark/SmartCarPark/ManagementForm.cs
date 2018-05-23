using SmartCarPark.Models;
using System;
using System.Windows.Forms;

namespace SmartCarPark
{
    public partial class ManagementForm : Form
    {
        public ManagementForm()
        {
            InitializeComponent();
        }

        public enum ManagementDataType
        {
            Apartment,
            Car
        }

        public ManagementDataType _dataType { get; set; }
        private int _primaryKey;

        private void ApartmentManagementForm_Load(object sender, EventArgs e)
        {
            BindDataview();
        }

        private void tsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Text == "Cars")
            {
                _dataType = ManagementDataType.Car;
                BindDataview();
            }
            else if (item.Text == "Apartments")
            {
                _dataType = ManagementDataType.Apartment;
                BindDataview();
            }
            else if (item.Text == "Add New")
            {
                AddData frm = new AddData();
                frm._dataType = _dataType;
                frm.ShowDialog();
            }
        }

        private void BindDataview()
        {
            grdDatas.Columns.Clear();
            if (_dataType == ManagementDataType.Apartment)
            {
                grdDatas.DataSource = Apartment.List();
            }
            else
            {
                grdDatas.DataSource = Car.List();
            }

            DataGridViewButtonColumn editBtnColumn = new DataGridViewButtonColumn { Text = "Edit", UseColumnTextForButtonValue = true, Name = "Edit", DisplayIndex = grdDatas.Columns.Count };
            grdDatas.Columns.Add(editBtnColumn);

            DataGridViewButtonColumn deleteBtnColumn = new DataGridViewButtonColumn { Text = "Delete", UseColumnTextForButtonValue = true, Name = "Delete", DisplayIndex = grdDatas.Columns.Count };
            grdDatas.Columns.Add(deleteBtnColumn);
        }

        private void GrdDatas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewButtonColumn btn = (DataGridViewButtonColumn)senderGrid.Columns[e.ColumnIndex];
                _primaryKey = int.Parse(senderGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                switch (btn.Text)
                {
                    case "Edit":
                        EditData frm = new EditData();
                        frm._dataType = _dataType;
                        frm._pk = _primaryKey;
                        frm.ShowDialog();
                        break;
                    case "Delete":
                        DeleteData(_primaryKey);
                        break;
                }
            }
            BindDataview();
        }

        private void DeleteData(int _pk)
        {
            DialogResult dialogResult = MessageBox.Show("Silme işleminden emin misiniz?", "Veri Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                switch (_dataType)
                {
                    case ManagementDataType.Apartment:
                        Apartment.Delete(_pk);
                        break;
                    case ManagementDataType.Car:
                        Car.Delete(_pk);
                        break;
                }
            }
        }

    }
}
