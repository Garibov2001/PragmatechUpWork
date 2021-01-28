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
    public class ProjectTaskMilestoneProofManager : IProjectTaskMilestoneProofService
    {
        private readonly IProjectTaskMilestoneProofDal taskMilestoneProofDal;
        public ProjectTaskMilestoneProofManager(IProjectTaskMilestoneProofDal _taskMilestoneProofDal)
        {
            taskMilestoneProofDal = _taskMilestoneProofDal;
        }

        public async Task<bool> Add(ProjectTaskMilestoneProof taskMilestoneProof)
        {
            bool result = await taskMilestoneProofDal.Create(taskMilestoneProof);

            return result == true ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            ProjectTaskMilestoneProof proof = await GetTaskMilestoneProofByID(id);

            bool result = await taskMilestoneProofDal.Delete(proof);

            return result == true ? true : false;
        }

        public Task<List<ProjectTaskMilestoneProof>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProjectTaskMilestoneProof>> GetProofsByMilestoneID(int id)
        {
            return await taskMilestoneProofDal.GetAll(x => x.MilestoneId == id);
        }

        public async Task<ProjectTaskMilestoneProof> GetTaskMilestoneProofByID(int id)
        {
            return await taskMilestoneProofDal.Get(x => x.ID == id);
        }

        public async Task<bool> Update(ProjectTaskMilestoneProof taskMilestoneProof)
        {
            bool result = await taskMilestoneProofDal.Update(taskMilestoneProof);

            return result == true ? true : false;
        }

        public async Task<bool> UpdateForProof(ProjectTaskMilestoneProof taskMilestoneProof)
        {
            bool result = await taskMilestoneProofDal.UpdateForProof(taskMilestoneProof);
            return result == true ? true : false;
        }
    }
}
