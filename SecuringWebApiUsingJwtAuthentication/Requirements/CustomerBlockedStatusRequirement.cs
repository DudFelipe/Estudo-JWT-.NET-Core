using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.Requirements
{
    public class CustomerBlockedStatusRequirement : IAuthorizationRequirement
    {
        public bool IsBlocked { get; }

        public CustomerBlockedStatusRequirement(bool isBlocked)
        {
            IsBlocked = isBlocked;
        }
    }
}
