using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class AllApliedTasksWithOthers
    {
        public List<UserApplyAndConfirmTask> appliedTasks { get; set; }
        public UserApplyAndConfirmTask appliedTask { get; set; }
    }
}
