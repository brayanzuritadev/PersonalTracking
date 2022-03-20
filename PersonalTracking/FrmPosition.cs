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
    public partial class FrmPosition : Form
    {
        public FrmPosition()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //crear una lista de tipo DEPARTMENT
        List<DEPARTMENT> departmentList = new List<DEPARTMENT>();
        private void FrmPosition_Load(object sender, EventArgs e)
        {
            departmentList = DepartmentBLL.GetDepartment();

            //agregamos la informacion optenida a el combobox
            cmbDepartment.DataSource = departmentList;

            //mostramos los nombres de los departamentos a los usuarios
            cmbDepartment.DisplayMember = "DepartmentName";

            //usamos el ID para hacer operaciones en base de datos
            cmbDepartment.ValueMember = "ID";

            //-1 para qu eno se muestre ningun tipo de informacion al momento de iniciar el form
            cmbDepartment.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPosition.Text.Trim() == "")
                MessageBox.Show("Please fill the position name field");
            else if (cmbDepartment.SelectedIndex == -1)
                MessageBox.Show("Please select a department");
            else
            {
                //creamos una variable de tipo POSITION 
                POSITION position = new POSITION();
                
                //llenamos la variable de tipo POSITIOn con los datos del frm
                position.PositionName = txtPosition.Text;
                position.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                PositionBLL.AddPosition(position);
                MessageBox.Show("Position was added");
                //limpiamos los campos
                txtPosition.Clear();
                cmbDepartment.SelectedIndex = -1;
            }
        }
    }
}
