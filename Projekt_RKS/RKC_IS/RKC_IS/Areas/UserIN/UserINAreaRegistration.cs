using System.Web.Mvc;

namespace RKC_IS.Areas.UserIN
{
    public class UserINAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserIN";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UserIN_default",
                "UserIN/{controller}/{action}/{id}",
                new { controler = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "RKC_IS.Areas.UserIN.Controllers" }
            );
        }
    }
}