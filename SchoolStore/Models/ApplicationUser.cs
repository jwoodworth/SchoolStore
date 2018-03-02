using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStore.Models
{
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public ApplicationUser()
        {
            Reviews = new HashSet<Review>();
        }

        //ApplicationUser good way to extend Identity to your needs
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Add favorite school
        public string FavoriteSchool { get; set; }

        //A user can author many reviews
        public ICollection<Review> Reviews { get; set; }

        //Reviewed and good for SchoolStore v2 after modifications
    }
}