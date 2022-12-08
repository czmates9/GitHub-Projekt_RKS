using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKC_IS.DataAccess.Model
{
    public class MyUserStore : UserStore<MyUser, MyRole, int, MyUserLogin, MyUser_Role, MyUserClaim>
    {
        public MyUserStore(MyDbContext context)
            : base(context)
        {
        }
    }
}
