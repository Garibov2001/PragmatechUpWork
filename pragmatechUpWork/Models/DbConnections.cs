using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork.Models
{
    public class DbConnections : DbContext
    {
        public DbConnections(DbContextOptions<DbConnections> options)
            : base(options)
        {



        }

        public DbSet<Project> Project { get; set; }
        public DbSet<Task> Task { get; set; }

    }
}
