using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace ECSytem.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeUserAttribute : Attribute, IAsyncActionFilter
    {
        string role;
        public AuthorizeUserAttribute(string role)
        {
            this.role = role;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string assignedRole = context.HttpContext.User.Identity.AuthenticationType;
            string role = this.role;

            if (assignedRole != role)
            {
                context.Result = new RedirectResult("/");
            }
            else
            {
                await next();
            }
        }
    }
}