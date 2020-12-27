using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork.Data
{
    public class UpWrokDbConnections : DbContext
    {
        public UpWrokDbConnections(DbContextOptions<UpWrokDbConnections> options)
            : base(options)
        {



        }

        public DbSet<Project> project { get; set; }

    }
}
