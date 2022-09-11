using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OCMS03.Models.ViewModels
{
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}
