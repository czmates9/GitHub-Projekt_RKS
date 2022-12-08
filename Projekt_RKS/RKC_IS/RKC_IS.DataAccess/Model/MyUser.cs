using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RKC_IS.DataAccess.Model
{
    public class MyUser : IdentityUser<int, MyUserLogin, MyUser_Role, MyUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<MyUser,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //public MyUser()
        //{ 
        //  this.C_DATE = DateTime.Now;
        //  this.STAV = 1;
        //  this.Telefon = PhoneNumber;
        //}

        //public USER()
        //{
        //    this.AP_HISTORIE = new HashSet<AP_HISTORIE>();
        //    this.FORMA_OPRAVA = new HashSet<FORMA_OPRAVA>();
        //    this.MEZNI_VZOREK = new HashSet<MEZNI_VZOREK>();
        //    this.STROJ_PORUCHA = new HashSet<STROJ_PORUCHA>();
        //    this.STROJ_UDRZBA = new HashSet<STROJ_UDRZBA>();
        //    this.USER_ROLE = new HashSet<USER_ROLE>();
        //    this.USER_VZORKOVANI = new HashSet<USER_VZORKOVANI>();
        //    this.ZAKAZKA_RECORD = new HashSet<ZAKAZKA_RECORD>();
        //    this.UserClaim = new HashSet<UserClaim>();
        //    this.UserLogin = new HashSet<UserLogin>();
        //}

        //public MyUser()
        //{
        //    this.AP_HISTORIE = new HashSet<AP_HISTORIE>();
        //    this.FORMA_OPRAVA = new HashSet<FORMA_OPRAVA>();
        //    this.MEZNI_VZOREK = new HashSet<MEZNI_VZOREK>();
        //    this.STROJ_PORUCHA = new HashSet<STROJ_PORUCHA>();
        //    this.STROJ_UDRZBA = new HashSet<STROJ_UDRZBA>();
        //    this.USER_ROLE = new HashSet<USER_ROLE>();
        //    this.USER_VZORKOVANI = new HashSet<USER_VZORKOVANI>();
        //    this.ZAKAZKA_RECORD = new HashSet<ZAKAZKA_RECORD>();
        //    this.UserClaim = new HashSet<UserClaim>();
        //    this.UserLogin = new HashSet<UserLogin>();
        //}

        //public override int Id { get; set; }
        public string ZAOR_organizace { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public Nullable<int> OsobniCislo { get; set; }
        //public string Telefon { get; set; }
        public string Obec { get; set; }
        public string Ulice { get; set; }
        public string CisloDomu { get; set; }
        public Nullable<int> PSC { get; set; }
        public Nullable<System.DateTime> DatumNastup { get; set; }
        public string PlatovaTrida { get; set; }
        public string Smena { get; set; }
        public Nullable<System.DateTime> CasPrihlaseni { get; set; }
        public int C_USER { get; set; }
        public string M_USER { get; set; }
        public System.DateTime C_DATE { get; set; }
        public Nullable<System.DateTime> M_DATE { get; set; }
        //public string UserName { get; set; }
        //public string PasswordHash { get; set; }
        //public string Email { get; set; }
        public int STAV { get; set; }
        public Nullable<int> STAV_NASLEDUJICI { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<AP_HISTORIE> AP_HISTORIE { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<FORMA_OPRAVA> FORMA_OPRAVA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<MEZNI_VZOREK> MEZNI_VZOREK { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<STROJ_PORUCHA> STROJ_PORUCHA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<STROJ_UDRZBA> STROJ_UDRZBA { get; set; }
        ////public virtual SY_STAV SY_STAV { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ////public virtual ICollection<USER_ROLE> USER_ROLE { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<USER_VZORKOVANI> USER_VZORKOVANI { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ZAKAZKA_RECORD> ZAKAZKA_RECORD { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UserClaim> UserClaim { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UserLogin> UserLogin { get; set; }

    }
}
