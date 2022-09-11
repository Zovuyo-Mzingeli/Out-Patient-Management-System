﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OCMS03.Models;

namespace OCMS03.Infrastructure
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public AppClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        //public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        //{
        //    var principal = await base.CreateAsync(user);

        //    ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
        //        new Claim(ClaimTypes.GivenName, user.FirstName),
        //        new Claim(ClaimTypes.Surname, user.LastName),
        //    });

        //    return principal;
        //}
    }
}
