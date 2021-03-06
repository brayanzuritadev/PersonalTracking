using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DAL;

namespace BLL
{
    public class EmployeeBLL
    {
        //este metodo actualiza al empleado
        public static void UpdateEmployee(EMPLOYEE employee)
        {
            EmployeeDAO.UpdateEmployee(employee);
        }

        //este metodo retorna un de tipo EmployeeDTO
        public static EmployeeDTO GetAll()
        {
            EmployeeDTO dto = new EmployeeDTO();
            dto.Deparments = DepartmentDAO.GetDepartment();
            dto.Positions = PositionDAO.GetPosition();
            dto.Employees = EmployeeDAO.GetEmployees();
            return dto;
        }

        public static void AddEmployee(EMPLOYEE employee)
        {
            EmployeeDAO.AddEmployee(employee);
        }

        public static bool isUnique(int v)
        {
            List<EMPLOYEE> list = EmployeeDAO.GetUsers(v);
            if(list.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static List<EMPLOYEE> GetCredencial(int userNo, string password)
        {
            return EmployeeDAO.GetCredencial(userNo, password);
        }

        public static void DeleteEmployee(int employeeID)
        {
            EmployeeDAO.DeleteEmployee(employeeID);
        }
    }

}
