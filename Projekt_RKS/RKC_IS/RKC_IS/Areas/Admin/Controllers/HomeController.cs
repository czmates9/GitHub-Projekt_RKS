using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RKC_IS.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ////inicializace spravceRoli a nasledny zapis role
            //RoleManager<MyRole, int> spravceRoli = new RoleManager<MyRole, int>(new RoleStore<MyRole, int, MyUser_Role>(new MyDbContext()));
            ////zapis "ROLE" 
            //spravceRoli.Create(new MyRole("operator", "operátor"));

            ////inicializace spravceUzivatelu a nasledny zapis role
            //UserManager<MyUser, int> spravceUzivatelu = new UserManager<MyUser, int>(new UserStore<MyUser, MyRole, int,
            //MyUserLogin, MyUser_Role, MyUserClaim>(new MyDbContext()));

            ////najit uzivatele UserName = "USERNAME" 
            //MyUser uzivatel = spravceUzivatelu.FindByName("CZmates9");

            ////zapis integrity role++Uzivatel== ID.USER a ID.ROLE
            //spravceUzivatelu.AddToRole(uzivatel.Id, "admin");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}