namespace MotoKS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PostCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PostCode");
        }
    }
}
