using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.DAO
{
    public class TaskDAO : EmployeeContext
    {
        //eliminar task
        public static void DeleteTask(int taskID){
            try
            {
                TASK task = db.TASK.First(x => x.ID == taskID);
                db.TASK.DeleteOnSubmit(task);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateTask(TASK updateTask)
        {
            try
            {
                TASK task = db.TASK.First(x => x.ID == updateTask.ID);
                task.TaskTitle = updateTask.TaskTitle;
                task.TaskContent = updateTask.TaskContent;
                task.TaskState = updateTask.TaskState;
                task.EmployeeID = updateTask.EmployeeID;
                db.SubmitChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<TASKSTATE> GetTaskState()
        {
            return db.TASKSTATE.ToList();
        }

        public static void ApproveTask(int taskID, bool isAdmin)
        {
            try
            {
                TASK task = db.TASK.First(x => x.ID==taskID);
                if (isAdmin)
                {
                    task.TaskState=TaskStates.Approved;
                }
                else
                {
                    task.TaskState = TaskStates.Delivered;
                }
                task.TaskDeliveryDate = DateTime.Today;
                db.SubmitChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddTask(TASK task)
        {
            try
            {
                db.TASK.InsertOnSubmit(task);
                db.SubmitChanges();

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<TaskDetailDTO> GetTasks()
        {
            List<TaskDetailDTO> taskList = new List<TaskDetailDTO>();

            var list = (from t in db.TASK
                        join ts in db.TASKSTATE on t.TaskState equals ts.ID
                        join e in db.EMPLOYEE on t.EmployeeID equals e.ID
                        join d in db.DEPARTMENT on e.DepartmentID equals d.ID
                        join p in db.POSITION on e.PositionID equals p.ID

                        select new
                        {
                            taskID= t.ID,
                            title = t.TaskTitle,
                            content = t.TaskContent,
                            startdate = t.TaskStartDate,
                            deliveryDate = t.TaskDeliveryDate,
                            taskStateName = ts.StateName,
                            taskStateID = t.TaskState,
                            UserNo = e.UserNo,
                            Name = e.Name,
                            EmployeeID=t.EmployeeID,
                            Surname = e.Surname,
                            positionName = p.PositionName,
                            departmentName = d.DepartmentName,
                            positionID = e.PositionID,
                            departmentID=e.DepartmentID,

                        }).OrderBy(x => x.startdate).ToList();

            foreach (var item in list)
            {
                TaskDetailDTO dto = new TaskDetailDTO();
                dto.TaskID = item.taskID;
                dto.Title = item.title;
                dto.Content = item.content;
                dto.TaskStartDate = item.startdate;
                dto.TaskDeliveryDate = item.deliveryDate;
                dto.TaskStateName = item.taskStateName;
                dto.TaskStateID = item.taskStateID;
                dto.UserNo = item.UserNo;
                dto.Name = item.Name;
                dto.Surname = item.Surname;
                dto.DepartmentID = item.departmentID;
                dto.DepartmentName = item.departmentName;
                dto.PositionID = item.positionID;
                dto.PositionName = item.positionName;
                dto.EmployeeID = item.EmployeeID;

                taskList.Add(dto);
            }
            return taskList;

        }
    }
}
