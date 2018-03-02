using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStore.Models
{
    public class Review
    {
        public Review()
        {
            Reviews = new HashSet<Review>();
         }
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public bool IsApproved { get; set; }

        public Products Product { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }




}
