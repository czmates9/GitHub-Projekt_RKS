using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKC_IS.DataAccess.Model
{
    public class MyRole : IdentityRole<int, MyUser_Role>
    {
        public MyRole() { }
        public MyRole(string nazevRole , string popisRole) 
        { 
            Name = nazevRole;
            POPIS_ROLE = popisRole;
            STAV = 5;
            C_DATE = DateTime.Now;
            C_USER = 1;

            //this.MyUser_Role = new HashSet<MyUser_Role>();
            //this.MyUser = new HashSet<MyUser>();
        }

        //public ROLE()
        //{
        //    this.SY_MODUL_ROLE = new HashSet<SY_MODUL_ROLE>();
        //    this.SY_MODUL_ROLE1 = new HashSet<SY_MODUL_ROLE>();
        //    this.SY_POLOZKA_STAV = new HashSet<SY_POLOZKA_STAV>();
        //    this.SY_POLOZKA_STAV1 = new HashSet<SY_POLOZKA_STAV>();
        //    this.SY_POLOZKA_STAV2 = new HashSet<SY_POLOZKA_STAV>();
        //    this.SY_POLOZKA_STAV3 = new HashSet<SY_POLOZKA_STAV>();
        //    this.USER_ROLE = new HashSet<USER_ROLE>();
        //    this.USER_ROLE1 = new HashSet<USER_ROLE>();
        //}

        //public int ID { get; set; }
        public Nullable<int> STAV { get; set; }
        //public string ZKRATKA { get; set; }
        public string POPIS_ROLE { get; set; }
        public Nullable<int> STAV_NASLEDUJICI { get; set; }
        public Nullable<int> C_USER { get; set; }
        public Nullable<System.DateTime> C_DATE { get; set; }
        public Nullable<int> M_USER { get; set; }
        public Nullable<System.DateTime> M_DATE { get; set; }
        //public virtual ICollection<MyUser_Role> MyUser_Role { get; set; }
        //public virtual ICollection<MyUser> MyUser { get; set; }


        //public virtual SY_STAV SY_STAV { get; set; }
        //public virtual SY_STAV SY_STAV1 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SY_MODUL_ROLE> SY_MODUL_ROLE { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SY_MODUL_ROLE> SY_MODUL_ROLE1 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SY_POLOZKA_STAV> SY_POLOZKA_STAV { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SY_POLOZKA_STAV> SY_POLOZKA_STAV1 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SY_POLOZKA_STAV> SY_POLOZKA_STAV2 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SY_POLOZKA_STAV> SY_POLOZKA_STAV3 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<USER_ROLE> USER_ROLE { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<USER_ROLE> USER_ROLE1 { get; set; }
    }
}
