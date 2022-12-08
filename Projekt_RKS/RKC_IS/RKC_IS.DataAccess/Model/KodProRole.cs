using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKC_IS.DataAccess.Model
{
    public class KodProRole
    {


        ////inicializace spravceRoli a nasledny zapis role
        //RoleManager<MyRole, int> spravceRoli = new RoleManager<MyRole, int>(new RoleStore<MyRole, int, MyUser_Role>(new MyDbContext()));
        ////zapis "ROLE" 
        //spravceRoli.Create(new MyRole("admin", "administrátor"));

        ////inicializace spravceUzivatelu a nasledny zapis role
        //UserManager<MyUser, int> spravceUzivatelu = new UserManager<MyUser, int>(new UserStore<MyUser, MyRole, int,
        //MyUserLogin, MyUser_Role, MyUserClaim>(new MyDbContext()));

        ////najit uzivatele UserName = "USERNAME" 
        //MyUser uzivatel = spravceUzivatelu.FindByName("CZmates9");

        ////zapis integrity role++Uzivatel== ID.USER a ID.ROLE
        //spravceUzivatelu.AddToRole(uzivatel.Id, "admin");

    }
}
