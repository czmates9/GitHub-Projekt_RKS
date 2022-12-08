using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RKC_IS.DataAccess.Model;
using System.Threading.Tasks;

namespace RKC_IS.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
        }

        [TestMethod]
        public void TestCreateRole()
        {
            ////inicializace spravceRoli a nasledny zapis role
            //RoleManager<MyRole, int> spravceRoli = new RoleManager<MyRole, int>(new RoleStore<MyRole, int, MyUser_Role>(new MyDbContext()));
            ////zapis "ROLE" 
            //spravceRoli.Create(new MyRole("admin", "administrátor"));

            ////inicializace spravceUzivatelu a nasledny zapis role
            //UserManager<MyUser, int> spravceUzivatelu = new UserManager<MyUser, int>(new UserStore<MyUser, MyRole, int,
            //MyUserLogin, MyUser_Role, MyUserClaim>(new MyDbContext()));

            ////najit uzivatele UserName = "USERNAME" 
            //ApplicationUser uzivatel = spravceUzivatelu.FindByName("CZmates9");

            ////zapis integrity role++Uzivatel== ID.USER a ID.ROLE
            //spravceUzivatelu.AddToRole(uzivatel.Id, "LEV");

            MyRole role = new MyRole("admin", "Administrátor");

        }
    }
}
