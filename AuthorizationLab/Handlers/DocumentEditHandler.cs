using AuthorizationLab.Models;
using AuthorizationLab.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationLab.Handlers
{
    public class DocumentEditHandler : AuthorizationHandler<EditRequirement, Document>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EditRequirement requirement, Document resource)
        {
            if (resource.Author == context.User.FindFirst(ClaimTypes.Name).Value)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
