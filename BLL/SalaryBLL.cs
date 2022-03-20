using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.DAO;
using DAL;

namespace BLL
{
    public class SalaryBLL
    {
       public static SalaryDTO GetAll()
        {
            //vamos a rellenar los campos de SalaryDTO
            SalaryDTO dto = new SalaryDTO();
            dto.Employees = EmployeeDAO.GetEmployees();
            dto.Departments = DepartmentDAO.GetDepartment();
            dto.Positions = PositionDAO.GetPosition();
            dto.Months = SalaryDAO.GetMonths();
            return dto;
        }

        public static void AddSalary(SALARY salary)
        {
            SalaryDAO.AddSalary(salary);
        }
    }
}
