using Microsoft.EntityFrameworkCore;
using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_DataAccessLayer.Concrete.EntityFramework
{
    public class EfProjectTaskMilestoneDal : EntityRepositoryBase<ProjectTaskMilestone>, IProjectTaskMilestoneDal
    {
        public EfProjectTaskMilestoneDal(UpWorkContext context):base(context)
        {

        }
      
    }
}
