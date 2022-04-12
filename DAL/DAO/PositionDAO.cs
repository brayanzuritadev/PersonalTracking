using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PositionDAO : EmployeeContext
    {
        //delete position
        public static void DeletePosition(int ID)
        {
            try
            {
                POSITION p = db.POSITION.First(x => x.ID == ID);
                db.POSITION.DeleteOnSubmit(p);
                db.SubmitChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdatePosition(POSITION position)
        {
            try
            {
                POSITION p = db.POSITION.First(x=> x.ID == position.ID);
                p.PositionName = position.PositionName;
                p.DepartmentID = position.DepartmentID;
                db.SubmitChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void AddPosition(POSITION position)
        {
            try
            {
                db.POSITION.InsertOnSubmit(position);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PositionDTO> GetPosition()
        {
            try
            {
                var List = (from p in db.POSITION
                            join d in db.DEPARTMENT on p.DepartmentID equals d.ID
                            select new
                            {
                                positionID = p.ID,
                                positionName = p.PositionName,
                                departmentName = d.DepartmentName,
                                departmentID = p.DepartmentID
                            }).OrderBy(x => x.positionID).ToList();
                List<PositionDTO> positionList = new List<PositionDTO>();
                foreach (var item in List)
                {
                    PositionDTO dto = new PositionDTO();
                    dto.ID = item.positionID;
                    dto.PositionName = item.positionName;
                    dto.DepartmentName = item.departmentName;
                    dto.DepartmentID = item.departmentID;
                    positionList.Add(dto);
                }
                return positionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
