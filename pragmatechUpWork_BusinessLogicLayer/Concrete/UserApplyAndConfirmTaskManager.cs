using pragmatechUpWork_BusinessLogicLayer.Abstract;
using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Concrete
{
    class UserApplyAndConfirmTaskManager : IUserApplyAndConfirmTaskService
    {
        private readonly IUserApplyAndConfirmTaskDal applyTaskDal;
        public UserApplyAndConfirmTaskManager(IUserApplyAndConfirmTaskDal _applyTaskDal)
        {
            applyTaskDal = _applyTaskDal;
        }
        public async Task<bool> Add(UserApplyAndConfirmTask appliedTask)
        {
            bool result = await applyTaskDal.Create(appliedTask);

            return result == true ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            UserApplyAndConfirmTask appliedTask = await GetAppliedTasksByID(id);

            bool result = await applyTaskDal.Delete(appliedTask);

            return result == true ? true : false;
        }

        public async Task<List<UserApplyAndConfirmTask>> GetAll()
        {
            return await applyTaskDal.GetAll();
        }

        public async Task<List<UserApplyAndConfirmTask>> GetAllDescending()
        {
            List<UserApplyAndConfirmTask> appliedTasks = await applyTaskDal.GetAll();
            return appliedTasks.OrderByDescending(x => x.ApplyDate).ToList();
        }

        public async Task<UserApplyAndConfirmTask> GetAppliedTasksByID(int id)
        {
            return await applyTaskDal.Get(x => x.Id == id);
        }

        public async Task<bool> Update(UserApplyAndConfirmTask appliedTask)
        {
            bool result = await applyTaskDal.Update(appliedTask);

            return result == true ? true : false;
        }
    }
}
