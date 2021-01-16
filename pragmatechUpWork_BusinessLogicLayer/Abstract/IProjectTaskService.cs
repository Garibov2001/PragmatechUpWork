using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Abstract
{
    public interface IProjectTaskService
    {
        Task<List<ProjectTask>> GetAll();
        Task<ProjectTask> GetTasksByID(int id);
        Task<ProjectTask> GetTaskByName(string name);
        Task<List<ProjectTask>> GetTasksByProjet(int id);
        Task<List<ProjectTask>> GetTasksByCost(decimal Cost);
        Task<List<ProjectTask>> GetLastProjectTaskForCounter(int counter);
        Task<List<ProjectTask>> GetAllDescending();
        Task<bool> Add(ProjectTask projectTask);
        Task<bool> Update(ProjectTask projectTask);
        Task<bool> Delete(int id);
    }
}
