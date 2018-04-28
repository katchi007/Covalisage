using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace api.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string Adresse { get; set; }
        public ICollection<Annonce> annonces { get; set; }



    }
}