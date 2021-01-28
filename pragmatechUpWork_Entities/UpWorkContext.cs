using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace pragmatechUpWork_Entities
{
    public class UpWorkContext:DbContext
    {
        public UpWorkContext(DbContextOptions<UpWorkContext> options)
            : base(options)
        {



        }

        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectTask> Task { get; set; }
        public DbSet<UserApplyAndConfirmTask> ApplyTask { get; set; }
        public DbSet<ProjectTaskMilestone> TaskMilestone { get; set; }
        public DbSet<ProjectTaskMilestoneProof> TaskMilestoneProof { get; set; }

        // Bu Context'tir.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasKey(x => x.ProjectId);
            modelBuilder.Entity<ProjectTask>().HasKey(x => x.TaskId);
            modelBuilder.Entity<UserApplyAndConfirmTask>().HasKey(x => x.Id);
            modelBuilder.Entity<ProjectTaskMilestone>().HasKey(x => x.ID);
            modelBuilder.Entity<ProjectTaskMilestoneProof>().HasKey(x => x.ID);
        }
    }
}
