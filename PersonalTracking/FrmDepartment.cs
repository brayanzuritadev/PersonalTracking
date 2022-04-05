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
    public partial class FrmDepartment : Form
    {
        public bool isUpdate=false;
        public DEPARTMENT toUpdate;
        public FrmDepartment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtDepartment.Text.Trim()=="")
            {
                MessageBox.Show("Please fill the name field");
            }
            else
            {
                DEPARTMENT department = new DEPARTMENT();
                if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Are you sure","Warning!!",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {
                        department.ID = toUpdate.ID;
                        department.DepartmentName = txtDepartment.Text.ToString();
                        DepartmentBLL.UpdateDepartment(department);
                        MessageBox.Show("Department was update");
                        this.Close();
                    }
                }
                else 
                { 

                    
                    department.DepartmentName = txtDepartment.Text;
                    BLL.DepartmentBLL.AddDepartment(department);
                    MessageBox.Show("Department was added");
                    txtDepartment.Clear();
                }
            }
            
        }

        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                txtDepartment.Text = toUpdate.DepartmentName;
            }
        }
    }
}
