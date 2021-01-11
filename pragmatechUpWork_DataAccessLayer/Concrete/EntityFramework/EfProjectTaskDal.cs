using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pragmatechUpWork_DataAccessLayer.Concrete.EntityFramework
{
    public class EfProjectTaskDal:EntityRepositoryBase<ProjectTask>,IProjectTaskDal
    {
        public EfProjectTaskDal(UpWorkContext context):base(context)
        {

        }
    }
}
