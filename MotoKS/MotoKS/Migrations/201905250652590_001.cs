namespace MotoKS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(nullable: false),
                        Users_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Users_ID)
                .Index(t => t.Users_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        FirstName = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        CityName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Users_ID", "dbo.Users");
            DropIndex("dbo.Cars", new[] { "Users_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Cars");
        }
    }
}
