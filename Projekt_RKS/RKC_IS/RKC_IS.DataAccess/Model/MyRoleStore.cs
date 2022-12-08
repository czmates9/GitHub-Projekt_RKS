using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKC_IS.DataAccess.Model
{
    public class MyRoleStore : RoleStore<MyRole, int, MyUser_Role>
    {
        public MyRoleStore(MyDbContext context)
            : base(context)
        {
        }
    }
}
