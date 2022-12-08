namespace RKC_IS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpravaMapovaniTabulek_7 : DbMigration
    {
        public override void Up()
        {
           // RenameTable(name: "dbo.STROJs", newName: "STROJ");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.STROJ", newName: "STROJs");
        }
    }
}
