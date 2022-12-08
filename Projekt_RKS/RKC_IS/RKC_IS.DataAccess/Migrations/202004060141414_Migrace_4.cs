namespace RKC_IS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrace_4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.USER", "Telefon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.USER", "Telefon", c => c.String());
        }
    }
}
