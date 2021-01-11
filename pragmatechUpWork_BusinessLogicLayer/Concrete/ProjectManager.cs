using pragmatechUpWork_BusinessLogicLayer.Abstract;
using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDal projectDal;
        public ProjectManager(IProjectDal _projectDal)
        {
            projectDal = _projectDal;
        }
        public async Task<bool> Add(Project project)
        {
            bool result = await projectDal.Create(project);

            return result == true ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            Project project = await GetProjectByID(id);

            bool result = await projectDal.Delete(project);

            return result == true ? true : false;
        }

        public async Task<List<Project>> GetAll()
        {
            return await projectDal.GetAll();
        }

        public async Task<List<Project>> GetProjectsByCategory(string category)
        {
            return await projectDal.GetAll(x => x.Category == category);
        }

        public async Task<Project> GetProjectByID(int id)
        {
            return await projectDal.Get(x => x.ProjectId == id);
        }

        public async Task<List<Project>> GetProjectsByMinCostBetweenMaxCost(decimal minCost, decimal maxCost)
        {
            return await projectDal.GetAll(x => x.MinCost == minCost && x.MaxCost == maxCost);
        }

        public async Task<Project> GetProjectByName(string name)
        {
            return await projectDal.Get(x => x.Name == name);
        }

        public async Task<List<Project>> GetProjectsByProjectManager(string projectManager)
        {
            return await projectDal.GetAll(x => x.ProjectManager == projectManager);
        }

        public async Task<bool> Update(Project project)
        {
            bool result = await projectDal.Update(project);

            return result == true ? true : false;
        }

    }
}
