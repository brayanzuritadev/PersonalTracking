using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;

namespace BLL
{
    public class DepartmentBLL
    {
        //Delete a department

        public static void DeleteDepartment(int id)
        {
            DepartmentDAO.DeleteDepartment(id);
        }
        public static void AddDepartment(DEPARTMENT department)
        {
            DepartmentDAO.AddDepartment(department);
        }

        public static List<DEPARTMENT> GetDepartment()
        {
            return DepartmentDAO.GetDepartment();
        }

        public static void UpdateDepartment(DEPARTMENT department)
        {
            DepartmentDAO.UpdateDepartment(department);
        }
    }
}
