using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Providers.Entities;

namespace FA.JustBlog.Custom
{
    public static class UserExtension
    {
        public static ApplicationUser GetApplicationUser(this IIdentity identity)
        {
            if (identity.IsAuthenticated)
            {
                using (var db = new ApplicationDbContext())
                {
                    ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == identity.GetUserId());
                    //var user = UserManager.FindById(User.Identity.GetUserId());
                    return currentUser;
                }
                
            }
            else
            {
                return null;
            }
        }
    }
}