namespace RKC_IS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migraceMyUser : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.USER", "C_USER", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.USER", "C_USER", c => c.String());
        }
    }
}
