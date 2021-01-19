using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pragmatechUpWork_DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserApplyAndConfirmTaskDal : EntityRepositoryBase<UserApplyAndConfirmTask>, IUserApplyAndConfirmTaskDal
    {
        public EfUserApplyAndConfirmTaskDal(UpWorkContext context) : base(context)
        {

        }
    }
}
