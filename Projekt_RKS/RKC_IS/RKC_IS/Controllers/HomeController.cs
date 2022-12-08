using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RKC_IS.DataAccess.Model;
using RKC_IS.DataAccess.Model.AutoMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static RKC_IS.Controllers.ManageController;

namespace RKC_IS.Controllers
{
    public class HomeController : Controller
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();

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

        public ActionResult DetailUzivatele(int? ID_uzivatel, ManageMessageId? message)
        {

            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Vaše heslo bylo změněno"
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            if (ID_uzivatel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USER.Find(ID_uzivatel);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
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