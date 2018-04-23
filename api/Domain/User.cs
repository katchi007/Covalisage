using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace covalisage.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string CIN { get; set; }
        public string passeport { get; set; }
        public string Tel { get; set; }
        public string Gender { get; set; }
        public ICollection<Annonce> annonces { get; set; }



    }
}