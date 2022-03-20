using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    /// <summary>
    /// son todas las propidedades o variables de un salario
    /// </summary>
    public class SalaryDetailDTO
    {
        //Detail of Employee 
        public int EmployeeID { get; set; } 
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //position and department
        public int DepartmentID { get; set; }
        public int PsitionID { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }

        //Salary's employee
        public int SalaryID { get; set; }
        public int SalaryAmount { get; set; }
        public int oldSalary { get; set; }

        //Dates
        public int MonthID { get; set; }
        public string MonthName { get; set; }
        public int SalaryYear { get; set; }

    }
}
