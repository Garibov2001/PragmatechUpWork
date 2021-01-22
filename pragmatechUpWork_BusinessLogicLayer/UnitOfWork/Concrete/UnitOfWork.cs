using pragmatechUpWork_BusinessLogicLayer.Abstract;
using pragmatechUpWork_BusinessLogicLayer.Concrete;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_DataAccessLayer.Concrete.EntityFramework;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private UpWorkContext context;
        public UnitOfWork(UpWorkContext Context)
        {
            context = Context;
        }
        public IProjectService project { get; set; }
        public IProjectService Projects
        {
            get { return project ?? new ProjectManager(new EfProjectDal(context)); }
        }
        public IProjectTaskService projectTask { get; set; }
        public IProjectTaskService ProjectTasks 
        { 
            get { return projectTask ?? new ProjectTaskManager(new EfProjectTaskDal(context)); } 
        }

        public IUserApplyAndConfirmTaskService appliedTask { get; set; }
        public IUserApplyAndConfirmTaskService AplliedTasks 
        { 
            get { return appliedTask ?? new UserApplyAndConfirmTaskManager(new EfUserApplyAndConfirmTaskDal(context)); } 
        }

        public IProjectTaskMilestoneService taskMilestone { get; set; }
        public IProjectTaskMilestoneService TaskMilestones
        {
            get { return taskMilestone ?? new ProjectTaskMilestoneManager(new EfProjectTaskMilestoneDal(context)); }
        }

        public IUserApplyAndConfirmTaskService appliedTask { get; set; }
        public IUserApplyAndConfirmTaskService AplliedTasks 
        { 
            get { return appliedTask ?? new UserApplyAndConfirmTaskManager(new EfUserApplyAndConfirmTaskDal(context)); } 
        }
        public void Dispose()
        {
            context.DisposeAsync();
        }
    }
}
