using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.DTO;
using BLL;
using DAL;
using System.IO;

namespace PersonalTracking
{
    public partial class FrmEmployee : Form
    {
        public EmployeeDetailDTO toUpdate= new EmployeeDetailDTO();
        public bool isUpdate = false;
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        bool isUnique = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim()=="")
            {
                MessageBox.Show("User no is Empty");
            }
            else
            {
                isUnique = EmployeeBLL.isUnique(Convert.ToInt32(txtUserNo.Text));
                if (!isUnique)
                {
                    MessageBox.Show("This user no us used by another employee please change ");

                }
                else
                {
                    MessageBox.Show("This user is usable");
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserNo_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        //creamos un objeto EmployeeDTO
        EmployeeDTO dto = new EmployeeDTO();
        private string imagePath = "";
        private void FrmEmployee_Load_1(object sender, EventArgs e)
        {
             
                dto = EmployeeBLL.GetAll();

                cbDepartment.DataSource = dto.Deparments;
                cbDepartment.DisplayMember = "DepartmentName";
                cbDepartment.ValueMember = "ID";
                cbPosition.DataSource = dto.Positions;
                cbPosition.DisplayMember = "PositionName";
                cbPosition.ValueMember = "ID";
                //limpiamos
                cbPosition.SelectedIndex = -1;
                cbDepartment.SelectedIndex = -1;
                combofull = true;
            if (isUpdate)
            {
                txtUserNo.Text = Convert.ToString(toUpdate.UserNo);
                txtPassword.Text = Convert.ToString(toUpdate.Password);
                chbIsAdmin.Checked = Convert.ToBoolean(toUpdate.isAdmin);
                txtName.Text = Convert.ToString(toUpdate.Name);
                txtSurname.Text = Convert.ToString(toUpdate.Surname);
                imagePath = Application.StartupPath + "\\images\\" + toUpdate.ImagePath;
                txtIPath.Text = imagePath;
                pictureBox1.ImageLocation = imagePath;
                txtSalary.Text = toUpdate.Salary.ToString();
                txtDirection.Text = toUpdate.Adress;
                cbDepartment.SelectedValue = toUpdate.DepartmentID;
                cbPosition.SelectedValue = toUpdate.PositionID;
                dateTimePicker1.Value = Convert.ToDateTime(toUpdate.BhirtDay);

            }
            
        }
        //variable de validacion.
        bool combofull = false;

        private void cbDepartment_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //esto nos permite filtrar de manera correcta los departamentos 
            //para que cuando se elija un departamento solo se muestre las posiciones disponibles en ese departamento
            //pero mientras no se seleccione un departamento muestre todas las posiciones
            if (combofull)
            {
                int departmentID = Convert.ToInt32(cbDepartment.SelectedValue);
                cbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID == departmentID).ToList();
            }
        }


        string fileName = "";
        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            //esto nos permite cargar una imagen y su path.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                txtIPath.Text = openFileDialog1.FileName;
                
                //creamos un ID unico para unir al nombre del archivo y asi no se repita el nombre de los archivos.
                string Unique = Guid.NewGuid().ToString();
                fileName = fileName + Unique + openFileDialog1.SafeFileName;
            }


        }
        

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("User no is Empty");
            }
            
            
            else if (txtPassword.Text.Trim()=="")
            {
                MessageBox.Show("Password is Empty");
            }else if (txtName.Text.Trim()=="")
            {
                MessageBox.Show("Name is Empty");
            }
            else if (txtSurname.Text.Trim() == "")
            {
                MessageBox.Show("Surname is Empty");
            }
            else if (txtSalary.Text.Trim() == "")
            {
                MessageBox.Show("Salary is Empty");
            }
            else if (cbDepartment.SelectedIndex==-1)
            {
                MessageBox.Show("Select a Department");
            }
            else if (cbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Position");
            }

            else
            {
                if (!isUpdate)
                {
                    if (!EmployeeBLL.isUnique(Convert.ToInt32(txtUserNo.Text)))
                    {
                        MessageBox.Show("This user no us used by another employee please change ");
                    }

                    EMPLOYEE employee = new EMPLOYEE();

                    employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                    employee.Password = txtPassword.Text;
                    employee.Name = txtName.Text;
                    employee.Surname = txtSurname.Text;
                    employee.Salary = Convert.ToInt32(txtSalary.Text);
                    employee.DepartmentID = Convert.ToInt32(cbDepartment.SelectedValue);
                    employee.PositionID = Convert.ToInt32(cbPosition.SelectedValue);
                    employee.Adress = txtDirection.Text;
                    employee.BirthDay = dateTimePicker1.Value;
                    employee.ImagePath = fileName;
                    EmployeeBLL.AddEmployee(employee);
                    //copiamos la imagen en la carpeta images
                    File.Copy(txtIPath.Text, @"images\\" + fileName);
                    MessageBox.Show("Employes was added");
                    txtUserNo.Clear();
                    txtPassword.Clear();
                    // chbIsAdmin.Checked = Convert.ToBoolean(detail.isAdmin);
                    txtDirection.Clear();
                    txtIPath.Clear();
                    txtName.Clear();
                    txtSalary.Clear();
                    txtSurname.Clear();
                    cbDepartment.SelectedIndex = -1;
                    combofull = false;
                    pictureBox1.Image = null;
                    cbPosition.DataSource = dto.Positions;
                    cbPosition.SelectedIndex = -1;
                    combofull = true;
                    dateTimePicker1.Value = DateTime.Today;
                }else if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Are you sure?","Warning",MessageBoxButtons.YesNo);
                    if (result==DialogResult.Yes)
                    {
                        EMPLOYEE employee = new EMPLOYEE();
                        if (txtIPath.Text!=imagePath)
                        {
                            if (File.Exists(@"images\\" + toUpdate.ImagePath))
                            {
                                File.Delete(@"images\\"+toUpdate.ImagePath);
                                File.Copy(txtIPath.Text, @"images\\" + fileName);
                                employee.ImagePath = fileName;
                            }
                            else
                            {
                                employee.ImagePath = toUpdate.ImagePath;
                            }
                            employee.ID = toUpdate.EmployeeID;
                            employee.Name = txtName.Text;
                            employee.Surname = txtSurname.Text;
                            employee.Salary = Convert.ToInt32(txtSalary.Text);
                            employee.Adress = txtDirection.Text;
                            employee.DepartmentID = Convert.ToInt32(cbDepartment.SelectedValue);
                            employee.PositionID = Convert.ToInt32(cbPosition.SelectedValue);
                            employee.BirthDay = dateTimePicker1.Value;
                            employee.isAdmin = chbIsAdmin.Checked;
                            employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                            employee.Password = txtPassword.Text;
                            EmployeeBLL.UpdateEmployee(employee);
                            MessageBox.Show("Employee was updated");
                            this.Close();

                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
