namespace RKC_IS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZalozeniTabulek_3 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.ROLE", "SY_STAV_ID", "dbo.SY_STAV");
            //DropForeignKey("dbo.ROLE", "SY_STAV_ID1", "dbo.SY_STAV");
            //DropIndex("dbo.ROLE", new[] { "SY_STAV_ID" });
            //DropIndex("dbo.ROLE", new[] { "SY_STAV_ID1" });
            //DropColumn("dbo.ROLE", "SY_STAV_ID");
            //DropColumn("dbo.ROLE", "SY_STAV_ID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ROLE", "SY_STAV_ID1", c => c.Int());
            AddColumn("dbo.ROLE", "SY_STAV_ID", c => c.Int());
            CreateIndex("dbo.ROLE", "SY_STAV_ID1");
            CreateIndex("dbo.ROLE", "SY_STAV_ID");
            AddForeignKey("dbo.ROLE", "SY_STAV_ID1", "dbo.SY_STAV", "ID");
            AddForeignKey("dbo.ROLE", "SY_STAV_ID", "dbo.SY_STAV", "ID");
        }
    }
}
