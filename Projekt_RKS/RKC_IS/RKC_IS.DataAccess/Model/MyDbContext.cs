using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Data.Entity;

namespace RKC_IS.DataAccess.Model
{

    public class MyDbContext : IdentityDbContext<MyUser, MyRole, int, MyUserLogin, MyUser_Role, MyUserClaim>
    {
        

        //zde bude dedeni
        public MyDbContext()
            : base("DefaultConnection")
        {
        }

        public static MyDbContext Create()
        {
            return new MyDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyUser>().ToTable("USER");
            modelBuilder.Entity<MyUser>().ToTable("USER").Property(p => p.Id).HasColumnName("ID");

            modelBuilder.Entity<MyUser>().ToTable("USER").Property(p => p.STAV).HasColumnName("STAV");

            //modelBuilder.Entity<MyUser>().Property(p => p.PhoneNumber).HasColumnName("Telefon");



            modelBuilder.Entity<MyRole>().ToTable("ROLE");        
            //modelBuilder.Entity<MyRole>().ToTable("ROLE").Property(p => p.Id).HasColumnName("ID");
            modelBuilder.Entity<MyRole>().ToTable("ROLE").Property(p => p.Name).HasColumnName("ZKRATKA");



            modelBuilder.Entity<MyUser_Role>().ToTable("USER_ROLE");
            modelBuilder.Entity<MyUser_Role>().HasKey(r => new { r.ID }).ToTable("USER_ROLE");
            modelBuilder.Entity<MyUser_Role>().ToTable("USER_ROLE").Property(p => p.UserId).HasColumnName("ID_USER");
            modelBuilder.Entity<MyUser_Role>().ToTable("USER_ROLE").Property(p => p.RoleId).HasColumnName("ID_ROLE");



            //modelBuilder.Entity<MyRole>()
            //.HasForeignKey(r => new { r.ID })
            //.ToTable("ROLE");

            

            modelBuilder.Entity<MyUserLogin>()
                        .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                        .ToTable("UserLogin");
        }



    }



    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}


}
