namespace MotoKS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ProdDate", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Mileage", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Netto", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Negotiable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Damaged", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Damaged");
            DropColumn("dbo.Cars", "Negotiable");
            DropColumn("dbo.Cars", "Netto");
            DropColumn("dbo.Cars", "Mileage");
            DropColumn("dbo.Cars", "ProdDate");
        }
    }
}
