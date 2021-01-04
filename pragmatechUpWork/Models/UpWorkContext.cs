using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork.Models
{
    public class UpWorkContext : DbContext
    {
        public UpWorkContext(DbContextOptions<UpWorkContext> options)
            : base(options)
        {



        }

        public DbSet<Project> Project { get; set; }
        public DbSet<Task> Task { get; set; }

    }
}
