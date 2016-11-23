﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity.EntityFramework; // for IdentityUser
#endregion

namespace ChinookSystem.Security
{
    // This class represents logged on users
    // You can add User data for the user by adding more properties to you User class
    public class ApplicationUser : IdentityUser
    {
    }
}
