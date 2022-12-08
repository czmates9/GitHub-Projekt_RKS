using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


// Zde je rozdělení aplikace na autorizované části, kde je část "Admin" pro roli "admin"
// dále část UserIN pro, kteréhokoliv přihlášeného uživatele
// poslední je část bez přihlášení, úvodní

namespace RKC_IS
{
    ///check for various conditions based on the area it is in.
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var routeData = httpContext.Request.RequestContext.RouteData;
            var controller = routeData.GetRequiredString("controller");
            var action = routeData.GetRequiredString("action");
            var area = routeData.DataTokens["area"];
            var user = httpContext.User;
            if (area != null && area.ToString() == "UserIN")
            {
                if (!user.Identity.IsAuthenticated)
                    return false; // Once it return false ,then it will not come to current page any more
            }
            else if (area != null && area.ToString() == "Admin")
            {
                if (!user.Identity.IsAuthenticated)
                    return false;
                if (!user.IsInRole("admin"))
                    return false;
            }
            return true;
        }
    }
}