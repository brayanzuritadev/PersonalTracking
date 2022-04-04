using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.DAO
{
    public class SalaryDAO:EmployeeContext
    {
        public static void UpdateSalary(SALARY salary)
        {
            try
            {
                SALARY sl = db.SALARY.First(x=>x.ID==salary.ID);
                sl.Amount = salary.Amount;
                sl.Year = salary.Year;
                sl.MonthID = salary.MonthID;
                db.SubmitChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<MONTHS> GetMonths()
        {
            return db.MONTHS.ToList();
        }

        public static void AddSalary(SALARY salary)
        {
            try
            {
                db.SALARY.InsertOnSubmit(salary);
                db.SubmitChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<SalaryDetailDTO> GetSalaries()
        {
            List<SalaryDetailDTO> salaryList = new List<SalaryDetailDTO>();

            try
            {
                var list = (from s in db.SALARY
                            join e in db.EMPLOYEE on s.EmployeeID equals e.ID
                            join m in db.MONTHS on s.MonthID equals m.ID
                            select new
                            {
                                userNo= e.UserNo,
                                name = e.Name,
                                surname = e.Surname,
                                employeeID = s.EmployeeID,
                                amount = s.Amount,
                                year   = s.Year,
                                monthName= m.MonthName,
                                monthID =s.MonthID,
                                salaryID= s.ID,
                                departmentID=e.DepartmentID,
                                positionID = e.PositionID,
                            }).OrderBy(x=>x.year).ToList();

                foreach (var item in list)
                {
                    SalaryDetailDTO dto = new SalaryDetailDTO();
                    dto.UserNo = item.userNo;
                    dto.Name = item.name;
                    dto.Surname = item.surname;
                    dto.EmployeeID = item.employeeID;
                    dto.SalaryAmount = item.amount;
                    dto.SalaryYear = item.year;
                    dto.MonthName = item.monthName;
                    dto.MonthID = item.monthID;
                    dto.oldSalary = item.amount;
                    dto.SalaryID = item.salaryID;
                    dto.DepartmentID = item.departmentID;
                    dto.PositionID = item.positionID;
                    salaryList.Add(dto);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return salaryList;
        }
    }
}
