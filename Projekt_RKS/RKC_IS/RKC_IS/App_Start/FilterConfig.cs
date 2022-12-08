using System.Web;
using System.Web.Mvc;

namespace RKC_IS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomAuthorizeAttribute()); // it will apply to every controller
            filters.Add(new HandleErrorAttribute());
        }
    }
}
