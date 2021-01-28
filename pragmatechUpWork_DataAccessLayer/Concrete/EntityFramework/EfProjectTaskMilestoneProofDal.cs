using Microsoft.EntityFrameworkCore;
using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_DataAccessLayer.Concrete.EntityFramework
{
    public class EfProjectTaskMilestoneProofDal : EntityRepositoryBase<ProjectTaskMilestoneProof>, IProjectTaskMilestoneProofDal
    {
        private UpWorkContext _context;
        public EfProjectTaskMilestoneProofDal(UpWorkContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UpdateForProof(ProjectTaskMilestoneProof entity)
        {
            try
            {
                var modifiedEntity = _context.Entry(entity);
                modifiedEntity.State = EntityState.Detached;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string mesaj = ex.Message;
                return false;
            }
        }
    }
}
