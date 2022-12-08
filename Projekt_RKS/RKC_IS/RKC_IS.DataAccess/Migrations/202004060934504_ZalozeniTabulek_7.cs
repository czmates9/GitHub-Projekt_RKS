namespace RKC_IS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZalozeniTabulek_7 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.USER", "SY_STAV_ID", "dbo.SY_STAV");
            //DropIndex("dbo.USER", new[] { "SY_STAV_ID" });
            //DropColumn("dbo.USER", "SY_STAV_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.USER", "SY_STAV_ID", c => c.Int());
            CreateIndex("dbo.USER", "SY_STAV_ID");
            AddForeignKey("dbo.USER", "SY_STAV_ID", "dbo.SY_STAV", "ID");
        }
    }
}
