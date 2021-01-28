using pragmatechUpWork_BusinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectService Projects { get; }
        IProjectTaskService ProjectTasks { get; }
        IUserApplyAndConfirmTaskService AplliedTasks { get; }
        IProjectTaskMilestoneService TaskMilestones { get; }
        IProjectTaskMilestoneProofService TaskMilestoneProofs { get; }

    }
}
