using DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace PersonalTracking
{
    public partial class FrmPositionList : Form
    {
        bool isUpdate = false;
        PositionDTO toUpdate = new PositionDTO();
        public FrmPositionList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmPosition frm = new FrmPosition();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid();
        }

        List<PositionDTO> positionList = new List<PositionDTO>();
        
        void FillGrid()
        {
            positionList = PositionBLL.GetPosition();
            dataGridView1.DataSource = positionList;
        }
        private void FrmPositionList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[0].HeaderText = "Department Name";
            dataGridView1.Columns[3].HeaderText = "Position Name";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (toUpdate.ID == 0)
            {
                MessageBox.Show("Please choose a position");
            }
            else
            {
                FrmPosition frm = new FrmPosition();
                frm.isUpdate = true;
                frm.toUpdate = toUpdate;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                FillGrid();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            toUpdate.PositionName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            toUpdate.DepartmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            toUpdate.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            toUpdate.OldDepartment = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this position.", "Warning", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                PositionBLL.DeletePosition(toUpdate.ID);
                FillGrid();
            }
        }
    }
}
