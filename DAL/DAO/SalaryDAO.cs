﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class SalaryDAO:EmployeeContext
    {
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
    }
}
