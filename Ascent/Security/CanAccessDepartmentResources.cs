using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Ascent.Security
{
    public class CanAccessDepartmentResourcesRequirement : IAuthorizationRequirement
    {
        public string ClaimType { get; }

        public CanAccessDepartmentResourcesRequirement(string claimType)
        {
            ClaimType = claimType;
        }
    }

    public class CanAccessDepartmentResourcesHandler : AuthorizationHandler<CanAccessDepartmentResourcesRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CanAccessDepartmentResourcesHandler> _logger;

        public CanAccessDepartmentResourcesHandler(IHttpContextAccessor httpContextAccessor,
            ILogger<CanAccessDepartmentResourcesHandler> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            CanAccessDepartmentResourcesRequirement requirement)
        {
            var claimType = requirement.ClaimType;
            var dept = _httpContextAccessor.HttpContext.GetRouteData().Values["dept"].ToString();
            if (context.User.HasClaim(ClaimType.Admin, "true") || context.User.HasClaim(claimType, dept))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            var departments = context.User.FindFirst(claimType)?.Value;
            if (departments != null && departments.Split(',').Any(d => d == dept))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
