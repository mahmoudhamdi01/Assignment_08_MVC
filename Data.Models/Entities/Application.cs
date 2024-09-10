using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Entities
{
    public class Application : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
