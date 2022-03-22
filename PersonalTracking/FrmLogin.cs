using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.DAO;
using DAL;
using BLL;

namespace PersonalTracking
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtUserNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim()=="" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the UserNo and Password");

            }
            else
            {
                List<EMPLOYEE> Credencial = EmployeeBLL.GetCredencial(Convert.ToInt32(txtUserNo.Text.Trim()), txtPassword.Text.Trim());
                if(Credencial.Count == 0)
                {
                    MessageBox.Show("Please review your information");
                }
                else
                {
                    EMPLOYEE employee = new EMPLOYEE(); 
                    employee = Credencial.First();
                    UserStatic.EmployeeID = employee.ID;
                    UserStatic.UserNo = employee.UserNo;
                    UserStatic.IsAdmin = employee.isAdmin;

                    FrmMain frm = new FrmMain();
                    this.Hide();
                    frm.ShowDialog();
                }
            }
        }
    }
}
