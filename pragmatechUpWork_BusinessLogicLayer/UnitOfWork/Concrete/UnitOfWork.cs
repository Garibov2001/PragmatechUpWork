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
        public IProjectService Projects
        {
            get { return project ?? new ProjectManager(new EfProjectDal(context)); }
        }
        public IProjectTaskService ProjectTasks { get { return projectTask ?? new ProjectTaskManager(new EfProjectTaskDal(context)); } }
        public IProjectService project { get; set; }
        public IProjectTaskService projectTask { get; set; }

        public void Dispose()
        {
            context.DisposeAsync();
        }
    }
}
