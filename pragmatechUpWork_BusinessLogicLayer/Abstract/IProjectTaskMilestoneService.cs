using pragmatechUpWork_BusinessLogicLayer.Concrete;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Abstract
{
    public interface IProjectTaskMilestoneService
    {
        Task<List<ProjectTaskMilestone>> GetAll();
        Task<ProjectTaskMilestone> GetTaskMilestoneByID(int id);
        Task<ProjectTaskMilestone> GetTaskMilestoneByFilter(Expression<Func<ProjectTaskMilestone, bool>> expression);
        Task<bool> Add(ProjectTaskMilestone taskMilestone);
        Task<bool> Update(ProjectTaskMilestone taskMilestone);
        Task<bool> Delete(int id);
    }
}
