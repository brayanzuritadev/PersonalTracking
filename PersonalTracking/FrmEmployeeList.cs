using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DAL.DTO;
using BLL;

namespace PersonalTracking
{
    public partial class FrmEmployeeList : Form
    {

        EmployeeDTO dto = new EmployeeDTO();
        List<EmployeeDetailDTO> list;
        
        public FrmEmployeeList()
        {
            InitializeComponent();
        }
        private bool combofull = false;

        private void FrmEmployeeList_Load_1(object sender, EventArgs e)
        {
            FillAllData();
            
        }
        void FillAllData()
        {
            dto = EmployeeBLL.GetAll();
            dataGridView1.DataSource = dto.Employees;
            dto = EmployeeBLL.GetAll();
            dataGridView1.DataSource = dto.Employees;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].HeaderText = "Dapartment";
            dataGridView1.Columns[5].HeaderText = "Position";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Salary";
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            combofull = false;
            cbDepartment.DataSource = dto.Deparments;
            cbDepartment.DisplayMember = "DepartmentName";
            cbDepartment.ValueMember = "ID";
            cbPosition.DataSource = dto.Positions;
            cbPosition.DisplayMember = "PositionName";
            cbPosition.ValueMember = "ID";
            cbDepartment.SelectedIndex = -1;
            cbPosition.SelectedIndex = -1;
            combofull = true;
        }

        private void ReviewSearch()
        {
            List<EmployeeDetailDTO> list = dto.Employees;
            if (txtUserNo.Text.Trim() != "")
            {
                list = list.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            }
            if (txtName.Text.Trim() != "")
                list = list.Where(x => x.Name.Contains(txtName.Text)).ToList();
            if (txtSurname.Text.Trim() != "")
                list = list.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();
            if (cbDepartment.SelectedIndex != -1)
                list = list.Where(x => x.DepartmentID == Convert.ToInt32(cbDepartment.SelectedValue)).ToList();
            if (cbPosition.SelectedIndex != -1)
                list = list.Where(x => x.PositionID == Convert.ToInt32(cbPosition.SelectedValue)).ToList();
            dataGridView1.DataSource = list;

        }
        

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmEmployee frm = new FrmEmployee();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmEmployee frm = new FrmEmployee();
            frm.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                var AllPositionDepartment = dto.Positions.Where(x => x.DepartmentID == Convert.ToInt32(cbDepartment.SelectedValue)).ToList();
                cbPosition.DataSource = AllPositionDepartment;
          
                if (AllPositionDepartment.Count == 0)
                {
                    cbPosition.Text = "";
                    MessageBox.Show("There are not positions for this department");
                }
                ReviewSearch();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserNo_TextChanged(object sender, EventArgs e)
        {
            ReviewSearch();
        }
        
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ReviewSearch();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            ReviewSearch();
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                ReviewSearch();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            combofull = false;
            cbDepartment.SelectedIndex = -1;
            cbPosition.DataSource = dto.Positions;
            cbPosition.SelectedIndex = -1;
            combofull = true;
            dataGridView1.DataSource = dto.Employees;
        }
    }
}
