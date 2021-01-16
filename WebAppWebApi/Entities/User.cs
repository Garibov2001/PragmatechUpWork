using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWebApi.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Surnam { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ClassGroup { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
