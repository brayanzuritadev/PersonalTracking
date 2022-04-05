using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.DAO
{
    public class EmployeeDAO : EmployeeContext
    {
		//actualizamos el empleado
		public static void UpdateEmployee(EMPLOYEE employee)
        {
            try
            {
				EMPLOYEE emp = db.EMPLOYEE.First(x=>x.ID == employee.ID);
				emp.Adress = employee.Adress;
				emp.Name = employee.Name;
				emp.Salary = employee.Salary;
				emp.Password = employee.Password;
				emp.UserNo = employee.UserNo;
				emp.BirthDay = employee.BirthDay;
				emp.ImagePath = employee.ImagePath;
				emp.DepartmentID = employee.DepartmentID;
				emp.isAdmin = employee.isAdmin;
				emp.PositionID = employee.PositionID;
				emp.Surname = employee.Surname;
				db.SubmitChanges();
            }catch(Exception ex)
            {
				throw ex;
            }
        }

		public static void UpdateEmployee(int employeeID, int amount)
        {
            try
            {
				EMPLOYEE employee = db.EMPLOYEE.First(x => x.ID == employeeID);
				employee.Salary = amount;
				db.SubmitChanges();
            }catch(Exception ex)
            {
				throw ex;
            }
        }
		public static List<EMPLOYEE> GetCredencial(int userNo, string password)
        {
            try
            {
				List<EMPLOYEE> credencial = db.EMPLOYEE.Where(x=>x.UserNo == userNo && x.Password==password).ToList();
				return credencial;

            }catch (Exception ex)
            {
				throw ex;
            }
        }
        public static void AddEmployee(EMPLOYEE employee)
        {
            try
            {
                db.EMPLOYEE.InsertOnSubmit(employee);
                db.SubmitChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EMPLOYEE> GetUsers(int v)
        {
            //esto me trae el usuario con Id igual a "v"
            return db.EMPLOYEE.Where(x => x.UserNo == v).ToList();
        }

		public static List<EmployeeDetailDTO> GetEmployees()
		{
			List<EmployeeDetailDTO> employeeList = new List<EmployeeDetailDTO>();
			var list = (from e in db.EMPLOYEE
						join d in db.DEPARTMENT on e.DepartmentID equals d.ID
						join p in db.POSITION on e.PositionID equals p.ID
						select new
						{
							UserNo = e.UserNo,
							Name = e.Name,
							Surname = e.Surname,
							EmployeeID = e.ID,
							Password = e.Password,
							DepartmentName = d.DepartmentName,
							PositionName = p.PositionName,
							DepartmentID = e.DepartmentID,
							PositionId = e.PositionID,
							isAdmin = e.isAdmin,
							Salary = e.Salary,
							ImagePath = e.ImagePath,
							birthDay = e.BirthDay,
							Adress = e.Adress

						}).OrderBy(x => x.UserNo).ToList();
			foreach (var item in list)
			{
				EmployeeDetailDTO dto = new EmployeeDetailDTO();
				dto.Name = item.Name;
				dto.UserNo = item.UserNo;
				dto.Surname = item.Surname;
				dto.EmployeeID = item.EmployeeID;
				dto.Password = item.Password;
				dto.DepartmentID = item.DepartmentID;
				dto.DepartmentName = item.DepartmentName;
				dto.PositionID = item.PositionId;
				dto.PositionName = item.PositionName;
				dto.isAdmin = item.isAdmin;
				dto.Salary = item.Salary;
				dto.BhirtDay = item.birthDay;
				dto.Adress = item.Adress;
				dto.ImagePath = item.ImagePath;
				employeeList.Add(dto);
			}
			return employeeList;
		}
    }
}
