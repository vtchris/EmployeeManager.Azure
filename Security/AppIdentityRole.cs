using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Azure.Security
{
    public class AppIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
