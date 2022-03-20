using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalTracking
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            FrmEmployeeList frm = new FrmEmployeeList();
            this.Hide();   
            frm.ShowDialog();
            this.Visible = true;    
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            //visible muestra nuevamente el frm visible
            FrmTaskList frm = new FrmTaskList();
            frm.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            frmDepartmentList frm = new frmDepartmentList();
            frm.Hide();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            FrmPositionList frm = new FrmPositionList();
            frm.Hide();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
