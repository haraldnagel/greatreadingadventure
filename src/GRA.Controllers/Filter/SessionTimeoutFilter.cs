using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GRA.Controllers.Filter
{
    public class SessionTimeoutFilter : Attribute, IAsyncActionFilter
    {
        // TODO move this message to a customizable location
        private const string ExpiredMessage = "Your session has expired. Please sign in again.";

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // check if a user's session has gone away but they are still authenticated
            if (context.HttpContext.Session.GetInt32(SessionKey.ActiveUserId) == null
                && context.HttpContext.User.Identity.IsAuthenticated)
            {
                var controller = (Base.Controller)context.Controller;

                // by default redirect to Home/Index
                string redirectController = "Home";

                // if the user logged in recently we can redirect them to the authentication page
                var claim = context.HttpContext
                    .User
                    .Claims?
                    .FirstOrDefault(_ => _.Type == ClaimType.AuthenticatedAt);

                if (DateTime.TryParseExact(claim?.Value,
                    "O",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime authenticatedAt)
                    && (DateTime.Now - authenticatedAt).TotalHours < 2)
                {
                    redirectController = "SignIn";

                    controller.TempData[TempDataKey.AlertWarning] = ExpiredMessage;
                }

                int? siteId = context.HttpContext.Session.GetInt32(SessionKey.SiteId);
                context.HttpContext.Session.Clear();
                await context.HttpContext.SignOutAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
                context.HttpContext.User = null;
                if (siteId != null)
                {
                    context.HttpContext.Session.SetInt32(SessionKey.SiteId, (int)siteId);
                }

                context.Result = controller.RedirectToRoute(new
                {
                    area = string.Empty,
                    controller = redirectController,
                    action = "Index"
                });
            }
            else
            {
                await next();
            }
        }
    }
}
