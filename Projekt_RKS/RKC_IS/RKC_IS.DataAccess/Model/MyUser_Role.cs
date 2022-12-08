using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKC_IS.DataAccess.Model
{
    public class MyUser_Role : IdentityUserRole<int>
    {
        public int ID { get; set; }
        //public object ID_ROLE { get; internal set; }
        //public object ID_USER { get; internal set; }


        //public int ID { get; set; }
        //public int ID_USER { get; set; }
        //public int ID_ROLE { get; set; }
        //public bool L_PLATI { get; set; }

        //public virtual ROLE ROLE { get; set; }
        //public virtual ROLE ROLE1 { get; set; }
        //public virtual USER USER { get; set; }
    }
}
