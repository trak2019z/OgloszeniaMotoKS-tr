namespace MotoKS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _007 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "Favs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Favs", c => c.Int(nullable: false));
        }
    }
}
