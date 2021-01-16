using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_DataAccessLayer.Concrete.EntityFramework
{
    public class EfProjectDal:EntityRepositoryBase<Project>,IProjectDal
    {
        public EfProjectDal(UpWorkContext context):base(context)
        {

        }

    }
}
