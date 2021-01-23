using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pragmatechUpWork_BusinessLogicLayer.Abstract
{
    public interface IUserApplyAndConfirmTaskService
    {
        Task<List<UserApplyAndConfirmTask>> GetAll();
        Task<UserApplyAndConfirmTask> GetAppliedTasksByID(int id);
        Task<UserApplyAndConfirmTask> GetConfirmedByTaskID(int id);
        Task<List<UserApplyAndConfirmTask>> GetAppliedTasksByUserID(string userId);
        Task<List<UserApplyAndConfirmTask>> GetAppliedTasksByStatus(bool status);
        Task<List<UserApplyAndConfirmTask>> GetAllDescending();
        Task<bool> Add(UserApplyAndConfirmTask appliedTask);
        Task<bool> Update(UserApplyAndConfirmTask appliedTask);
        Task<bool> Delete(int id);
    }
}
