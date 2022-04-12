using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DTO;
namespace DAL.DAO
{
    public class PermissionDAO:EmployeeContext
    {
        public static void DeletePermission(int id)
        {
            try
            {
                PERMISSION pr = db.PERMISSION.First(x => x.ID == id);
                db.PERMISSION.DeleteOnSubmit(pr);
                db.SubmitChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void AddPermission(PERMISSION permission)
        {
            try
            {
                db.PERMISSION.InsertOnSubmit(permission);
                db.SubmitChanges();

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<PERMISSIONSTATE> GetAllPermissionStates()
        {
            try
            {
                return db.PERMISSIONSTATE.ToList();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PermissionDetailDTO> GetAllPermissions()
        {
            List<PermissionDetailDTO> permissions = new List<PermissionDetailDTO>();
            var list = (from p in db.PERMISSION
                        join s in db.PERMISSIONSTATE on p.PermissionState equals s.ID
                        join e in db.EMPLOYEE on p.EmployeeID equals e.ID
                        select new
                        {
                            UserNo = e.UserNo,
                            name = e.Name,
                            Surname = e.Surname,
                            StateName = s.StateName,
                            stateID = p.PermissionState,
                            startdate = p.PermissionStartDate,
                            endDate = p.PermissionEndDate,
                            employeeID = p.EmployeeID,
                            PermissionID = p.ID,
                            explanation = p.PermissionExplanation,
                            Dayamount = p.PermissionDay,
                            departmentID = e.DepartmentID,
                            positionID = e.PositionID

                        }).OrderBy(x => x.startdate).ToList();
            foreach (var item in list)
            {
                PermissionDetailDTO dto = new PermissionDetailDTO();
                dto.UserNo = item.UserNo;
                dto.Name = item.name;
                dto.Surname = item.Surname;
                dto.EmployeeID = item.employeeID;
                dto.PermissionDayAmount = item.Dayamount;
                dto.StartDate = item.startdate;
                dto.EndDate = item.endDate;
                dto.DepartmentID = item.departmentID;
                dto.PositionID = item.positionID;
                dto.State = item.stateID;
                dto.StateName = item.StateName;
                dto.Explanation = item.explanation;
                dto.PermissionID = item.PermissionID;
                permissions.Add(dto);
            }

            return permissions;
        }

        public static void UpdatePermission(PERMISSION permission)
        {
            try
            {
                PERMISSION pr = db.PERMISSION.First(x => x.ID == permission.ID);
                pr.PermissionStartDate = permission.PermissionStartDate;
                pr.PermissionEndDate = permission.PermissionEndDate;
                pr.PermissionDay = permission.PermissionDay;
                pr.PermissionExplanation = permission.PermissionExplanation;
                db.SubmitChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePermission(int permissionID,int approved)
        {
            try
            {
                PERMISSION pr = db.PERMISSION.First(x => x.ID == permissionID);
                pr.PermissionState = approved;
                db.SubmitChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
