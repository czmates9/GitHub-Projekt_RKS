namespace RKC_IS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrace_2 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.USER_ROLE");
            //AddPrimaryKey("dbo.USER_ROLE", new[] { "ID_USER", "ID_ROLE" });
            //DropColumn("dbo.ROLE", "ZKRATKA1");
            //DropColumn("dbo.USER_ROLE", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.USER_ROLE", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ROLE", "ZKRATKA1", c => c.String());
            DropPrimaryKey("dbo.USER_ROLE");
            AddPrimaryKey("dbo.USER_ROLE", "ID");
        }
    }
}
