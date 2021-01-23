using pragmatechUpWork_BusinessLogicLayer.Abstract;
using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Concrete
{
    public class ProjectTaskManager : IProjectTaskService
    {
        private readonly IProjectTaskDal projectTaskDal;
        public ProjectTaskManager(IProjectTaskDal _projectTaskDal)
        {
            projectTaskDal = _projectTaskDal;
        }
        public async Task<bool> Add(ProjectTask projectTask)
        {
            bool result = await projectTaskDal.Create(projectTask);

            return result == true ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            ProjectTask projectTask = await GetTaskByID(id);

            bool result = await projectTaskDal.Delete(projectTask);

            return result == true ? true : false;
        }

        public async Task<List<ProjectTask>> GetAll()
        {
            return await projectTaskDal.GetAll();
        }

        public async Task<List<ProjectTask>> GetAllDescending()
        {
            List<ProjectTask> projectsTasks = await projectTaskDal.GetAll();
            return projectsTasks.OrderByDescending(x => x.TaskId).ToList();
        }

        public async Task<List<ProjectTask>> GetLastProjectTaskForCounter(int counter)
        {
            List<ProjectTask> projectsTasks = await projectTaskDal.GetAll();
            return projectsTasks.OrderByDescending(x => x.TaskId).Take(counter).ToList();
        }

        public async Task<ProjectTask> GetTaskByID(int id)
        {
            return await projectTaskDal.Get(x => x.TaskId==id);
        }

        public async Task<ProjectTask> GetTaskByName(string name)
        {
            return await projectTaskDal.Get(x => x.Name==name);
        }

        public async Task<List<ProjectTask>> GetTasksByCost(decimal Cost)
        {
            return await projectTaskDal.GetAll(x => x.Cost==Cost);
        }

        public async Task<ProjectTask> GetTasksByID(int id)
        {
            return await  projectTaskDal.Get(x => x.TaskId == id);
        }

        public async Task<List<ProjectTask>> GetTasksByProjet(int id)
        {
            return await projectTaskDal.GetAll(x => x.ProjectId==id);
        }

        public async Task<bool> Update(ProjectTask projectTask)
        {
            bool result = await projectTaskDal.Update(projectTask);

            return result == true ? true : false;
        }
    }
}
