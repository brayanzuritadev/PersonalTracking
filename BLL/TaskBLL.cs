using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.DAO;
using DAL;

namespace BLL
{
    public class TaskBLL
    {
        //eliminar task
        public static void DeleteTask(int taskID)
        {
            TaskDAO.DeleteTask(taskID);
        }
        //esto devuelve un objeto de tipo TaskDTO
        public static TaskDTO GetAll()
        {
            TaskDTO taskdto = new TaskDTO();
            taskdto.Employees = EmployeeDAO.GetEmployees();
            taskdto.Departments = DepartmentDAO.GetDepartment();
            taskdto.Positions = PositionDAO.GetPosition();
            taskdto.TaskStates = TaskDAO.GetTaskState();
            taskdto.Task = TaskDAO.GetTasks();

            //retornamos taskdto
            return taskdto;
        }

        public static void AddTask(TASK task)
        {
            TaskDAO.AddTask(task);
        }
        public static void UpdateTask(TASK updateTask)
        {
            TaskDAO.UpdateTask(updateTask);
        }
    }
}
