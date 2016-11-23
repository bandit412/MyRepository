using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity.EntityFramework;    // UserStore
using Microsoft.AspNet.Identity;                    // UserManager
using System.ComponentModel;                        // ODS
using ChinookSystem.DAL;                            // DbContext
using ChinookSystem.Data.Entities;                  // For our own Entity classes
#endregion

namespace ChinookSystem.Security
{
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }
    }
}
