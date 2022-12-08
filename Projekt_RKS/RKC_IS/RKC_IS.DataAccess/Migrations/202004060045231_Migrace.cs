namespace RKC_IS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrace : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ROLE",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            STAV = c.Int(),
            //            ZKRATKA1 = c.String(),
            //            POPIS_ROLE = c.String(),
            //            STAV_NASLEDUJICI = c.Int(),
            //            C_USER = c.Int(),
            //            C_DATE = c.DateTime(),
            //            M_USER = c.Int(),
            //            M_DATE = c.DateTime(),
            //            ZKRATKA = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .Index(t => t.ZKRATKA, unique: true, name: "RoleNameIndex");
            
            //CreateTable(
            //    "dbo.USER_ROLE",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            ID_USER = c.Int(nullable: false),
            //            ID_ROLE = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.ROLE", t => t.ID_ROLE, cascadeDelete: true)
            //    .ForeignKey("dbo.USER", t => t.ID_USER, cascadeDelete: true)
            //    .Index(t => t.ID_USER)
            //    .Index(t => t.ID_ROLE);
            
            //CreateTable(
            //    "dbo.USER",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            ZAOR_organizace = c.String(),
            //            Jmeno = c.String(),
            //            Prijmeni = c.String(),
            //            OsobniCislo = c.Int(),
            //            Telefon = c.String(),
            //            Obec = c.String(),
            //            Ulice = c.String(),
            //            CisloDomu = c.String(),
            //            PSC = c.Int(),
            //            DatumNastup = c.DateTime(),
            //            PlatovaTrida = c.String(),
            //            Smena = c.String(),
            //            CasPrihlaseni = c.DateTime(),
            //            C_USER = c.String(),
            //            M_USER = c.String(),
            //            C_DATE = c.DateTime(nullable: false),
            //            M_DATE = c.DateTime(),
            //            STAV = c.Int(nullable: false),
            //            STAV_NASLEDUJICI = c.Int(),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.Int(nullable: false),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.USER", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.UserLogin",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.USER", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.USER_ROLE", "ID_USER", "dbo.USER");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.USER");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.USER");
            DropForeignKey("dbo.USER_ROLE", "ID_ROLE", "dbo.ROLE");
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.USER", "UserNameIndex");
            DropIndex("dbo.USER_ROLE", new[] { "ID_ROLE" });
            DropIndex("dbo.USER_ROLE", new[] { "ID_USER" });
            DropIndex("dbo.ROLE", "RoleNameIndex");
            DropTable("dbo.UserLogin");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.USER");
            DropTable("dbo.USER_ROLE");
            DropTable("dbo.ROLE");
        }
    }
}
