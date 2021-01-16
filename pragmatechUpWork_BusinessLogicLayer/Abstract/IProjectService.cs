using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Abstract
{
    public interface IProjectService
    {
        Task<List<Project>> GetAll();
        Task<Project> GetProjectByID(int id);
        Task<Project> GetProjectByName(string name);
        Task<Project> GetProjectByTask(ProjectTask task);
        Task<List<Project>> GetProjectsByCategory(string category);
        Task<List<Project>> GetProjectsByProjectManager(string projectManager);
        Task<List<Project>> GetProjectsByMinCostBetweenMaxCost(decimal minCost,decimal maxCost);
        Task<List<Project>> GetLastProjectsForCounter(int counter);
        Task<List<Project>> GetAllDescending();
        Task<bool> Add(Project project);
        Task<bool> Update(Project project);
        Task<bool> Delete(int id);

    }
}
