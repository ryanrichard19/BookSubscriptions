using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BookSubscriptions.Core.Domain.Entities
{
    // Add profile data for application users by adding properties to this class
    public class AppUser : IdentityUser
    {
        // Extended Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Subscribtion> Subscribtions { get; set; }
    }
}
