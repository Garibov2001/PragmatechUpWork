using pragmatechUpWork_GeneralLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pragmatechUpWork_Entities
{
    public class UserApplyAndConfirmTask : IEntity
    {
        public int Id { get; set; }
        public int TaskID { get; set; } 
        public string UserID { get; set; }
        public decimal Price { get; set; }
        public int Day { get; set; }
        public bool Status { get; set; }
        public DateTime? ApplyDate { get; set; }
        public ProjectTask Task { get; set; }
    }
}
