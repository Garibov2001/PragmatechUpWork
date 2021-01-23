using pragmatechUpWork_BusinessLogicLayer.Concrete;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Abstract
{
    public interface IProjectTaskMilestoneProofService
    {
        Task<List<ProjectTaskMilestoneProof>> GetAll();
        Task<List<ProjectTaskMilestoneProof>> GetProofsByMilestoneID(int id);
        Task<ProjectTaskMilestoneProof> GetTaskMilestoneProofByID(int id);
        Task<bool> Add(ProjectTaskMilestoneProof taskMilestoneProof);
        Task<bool> Update(ProjectTaskMilestoneProof taskMilestoneProof);
        Task<bool> Delete(int id);
    }
}
