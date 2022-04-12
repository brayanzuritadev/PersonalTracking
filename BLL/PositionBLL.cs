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
    public class PositionBLL
    {
        //eliminar position
        public static void DeletePosition(int ID)
        {
            PositionDAO.DeletePosition(ID);
        }
        public static void UpdatePosition(POSITION position, bool control)
        {
            PositionDAO.UpdatePosition(position);
            if (control == true)
                EmployeeDAO.UpdateEmployee(position);
        }
        public static void AddPosition(POSITION position)
        {
            PositionDAO.AddPosition(position);
        }

        public static List<PositionDTO> GetPosition()
        {
            return PositionDAO.GetPosition();
        }
    }
}
