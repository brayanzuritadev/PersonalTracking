using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;
using DAL.DTO;

namespace BLL
{
    public class PermissionBLL
    {
        public static void AddPermission(PERMISSION permission)
        {
            PermissionDAO.AddPermission(permission);
        }

        public static PermissionDTO GetAllPermission()
        {
            PermissionDTO dto = new PermissionDTO();
            dto.Departments = DepartmentDAO.GetDepartment();
            dto.Permissions = PermissionDAO.GetAllPermissions();
            dto.Positions = PositionDAO.GetPosition();
            dto.States = PermissionDAO.GetAllPermissionStates();
            return dto;
        }

        public static void UpdatePermission(PERMISSION permission)
        {
            PermissionDAO.UpdatePermission(permission);
        }

        public static void UpdatePermission(int permissionID, int approved)
        {
            PermissionDAO.UpdatePermission(permissionID, approved);
        }
    }
}
