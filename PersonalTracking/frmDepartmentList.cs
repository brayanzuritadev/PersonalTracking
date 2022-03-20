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
    }
}
