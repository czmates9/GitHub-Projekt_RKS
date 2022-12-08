namespace RKC_IS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrace_3 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.USER_ROLE");
            //AddColumn("dbo.USER_ROLE", "ID", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.USER_ROLE", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.USER_ROLE");
            DropColumn("dbo.USER_ROLE", "ID");
            AddPrimaryKey("dbo.USER_ROLE", new[] { "ID_USER", "ID_ROLE" });
        }
    }
}
