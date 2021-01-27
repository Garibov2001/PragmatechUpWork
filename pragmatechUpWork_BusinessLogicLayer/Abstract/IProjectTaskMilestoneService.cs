using pragmatechUpWork_BusinessLogicLayer.Concrete;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Abstract
{
    public interface IProjectTaskMilestoneService
    {
        Task<List<ProjectTaskMilestone>> GetAll();
        Task<ProjectTaskMilestone> GetTaskMilestoneByID(int id);
        Task<List<ProjectTaskMilestone>> GetTaskMileStonesByTaskID(int TaskID);
        Task<bool> Add(ProjectTaskMilestone taskMilestone);
        Task<bool> Update(ProjectTaskMilestone taskMilestone);
        Task<bool> Delete(int id);
    }
}
