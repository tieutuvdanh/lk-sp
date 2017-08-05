using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LikeSport.Model
{
   public  class ApplicationUser : IdentityUser
    {
        [MaxLength(256)]
        public string FisrtName { set; get; }

        [MaxLength(256)]
        public string LastName { set; get; }

        [MaxLength(10)]
        public string Gender { set; get; }

        [MaxLength(500)]
        public string Hobby { set; get; }

     
        public string Image { set; get; }

        public string Location { set; get; }

        public DateTime? BirthDay { set; get; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
