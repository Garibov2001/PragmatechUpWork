using pragmatechUpWork_BusinessLogicLayer.Abstract;
using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_Entities;
using pragmatechUpWork_BusinessLogicLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Concrete
{
    public class ProjectTaskMilestoneManager : IProjectTaskMilestoneService
    {
        private readonly IProjectTaskMilestoneDal taskMilestoneDal;
        public ProjectTaskMilestoneManager(IProjectTaskMilestoneDal _taskMilestoneDal)
        {
            taskMilestoneDal = _taskMilestoneDal;
        }

        public async Task<bool> Add(ProjectTaskMilestone taskMilestone)
        {
            bool result = await taskMilestoneDal.Create(taskMilestone);

            return result == true ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            ProjectTaskMilestone taskMilestone = await GetTaskMilestoneByID(id);

            bool result = await taskMilestoneDal.Delete(taskMilestone);

            return result == true ? true : false;
        }

        public async Task<List<ProjectTaskMilestone>> GetAll()
        {
            return await taskMilestoneDal.GetAll();
        }

        public async Task<ProjectTaskMilestone> GetTaskMilestoneByID(int id)
        {
            return await taskMilestoneDal.Get(x => x.ID == id);
        }

        public async Task<ProjectTaskMilestone> GetTaskMilestoneByFilter(Expression<Func<ProjectTaskMilestone, bool>> expression)
        {
            return await taskMilestoneDal.Get(expression);
        }

        public async Task<bool> Update(ProjectTaskMilestone taskMilestone)
        {
            bool result = await taskMilestoneDal.Update(taskMilestone);

            return result == true ? true : false;
        }
    }
}
