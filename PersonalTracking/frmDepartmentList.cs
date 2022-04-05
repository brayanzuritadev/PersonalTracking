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
    public partial class frmDepartmentList : Form
    {
        DEPARTMENT toUpdate = new DEPARTMENT();
        bool isUpdate = false;
        public frmDepartmentList()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmDepartment frm = new FrmDepartment();
            frm.Hide();
            frm.ShowDialog();
            this.Visible = true;

            //agregamos a la lista de tipo DEPARTMENT los datos traidos por Getdepartment que esta en el BLL
            list = DepartmentBLL.GetDepartment();
            dataGridView1.DataSource = list;
        }

       //aqui creamos la lista de tipo DEPARTMENT

        List<DEPARTMENT> list = new List<DEPARTMENT>();
        
        private void frmDepartmentList_Load(object sender, EventArgs e)
        {

            //agregamos a la lista de tipo DEPARTMENT los datos traidos por Getdepartment que esta en el BLL
            list = DepartmentBLL.GetDepartment();

            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Department Name";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (toUpdate.ID==0)
            {
                MessageBox.Show("Plese choose an department");
            }
            else
            {
                FrmDepartment frm = new FrmDepartment();
                frm.toUpdate = toUpdate;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible=true;
                list = DepartmentBLL.GetDepartment();
                dataGridView1.DataSource=list;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            toUpdate.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            toUpdate.DepartmentName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
