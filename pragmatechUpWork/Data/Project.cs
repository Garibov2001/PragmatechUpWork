using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pragmatechUpWork.Models;

namespace pragmatechUpWork.Data
{
    public class Project : ProjectModel
    {
        public int Id { get; set; }
        public int Status { get; set; }  // 1 - Aktiv, 2 -Arxiv, 3 - Draft


    }
}
