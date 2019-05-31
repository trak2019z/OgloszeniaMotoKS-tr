namespace MotoKS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Conversations", name: "User_ID", newName: "Users_ID");
            RenameIndex(table: "dbo.Conversations", name: "IX_User_ID", newName: "IX_Users_ID");
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Brand_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brands", t => t.Brand_ID)
                .Index(t => t.Brand_ID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Date = c.DateTime(nullable: false),
                        Who = c.Boolean(nullable: false),
                        Conversations_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Conversations", t => t.Conversations_ID)
                .Index(t => t.Conversations_ID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Car_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cars", t => t.Car_ID)
                .Index(t => t.Car_ID);
            
            CreateTable(
                "dbo.Favs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Car_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cars", t => t.Car_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Car_ID)
                .Index(t => t.User_ID);
            
            AddColumn("dbo.Cars", "Country", c => c.String());
            AddColumn("dbo.Cars", "VAT", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Leasing", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Engine", c => c.String(nullable: false));
            AddColumn("dbo.Cars", "bHP", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Color", c => c.String());
            AddColumn("dbo.Cars", "Desc", c => c.String());
            AddColumn("dbo.Cars", "FirstOwner", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "ASO", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "NoAcc", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "MainPhoto", c => c.String());
            AddColumn("dbo.Cars", "PostCode", c => c.String(nullable: false));
            AddColumn("dbo.Cars", "City", c => c.String(nullable: false));
            AddColumn("dbo.Cars", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Cars", "Favs", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Views", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Drive", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Fuel", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Gearbox", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "State", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Brand_ID", c => c.Int());
            AddColumn("dbo.Cars", "CarModel_ID", c => c.Int());
            AddColumn("dbo.Conversations", "Buyer_ID", c => c.Int());
            AddColumn("dbo.Conversations", "Car_ID", c => c.Int());
            AddColumn("dbo.Conversations", "Seller_ID", c => c.Int());
            AlterColumn("dbo.Users", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "CityName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false));
            CreateIndex("dbo.Cars", "Brand_ID");
            CreateIndex("dbo.Cars", "CarModel_ID");
            CreateIndex("dbo.Conversations", "Buyer_ID");
            CreateIndex("dbo.Conversations", "Car_ID");
            CreateIndex("dbo.Conversations", "Seller_ID");
            AddForeignKey("dbo.Cars", "Brand_ID", "dbo.Brands", "ID");
            AddForeignKey("dbo.Cars", "CarModel_ID", "dbo.Models", "ID");
            AddForeignKey("dbo.Conversations", "Buyer_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Conversations", "Car_ID", "dbo.Cars", "ID");
            AddForeignKey("dbo.Conversations", "Seller_ID", "dbo.Users", "ID");
            //DropColumn("dbo.Cars", "Brand");
            //DropColumn("dbo.Cars", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Model", c => c.String());
            AddColumn("dbo.Cars", "Brand", c => c.String());
            DropForeignKey("dbo.Favs", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Favs", "Car_ID", "dbo.Cars");
            DropForeignKey("dbo.Photos", "Car_ID", "dbo.Cars");
            DropForeignKey("dbo.Conversations", "Seller_ID", "dbo.Users");
            DropForeignKey("dbo.Messages", "Conversations_ID", "dbo.Conversations");
            DropForeignKey("dbo.Conversations", "Car_ID", "dbo.Cars");
            DropForeignKey("dbo.Conversations", "Buyer_ID", "dbo.Users");
            DropForeignKey("dbo.Cars", "CarModel_ID", "dbo.Models");
            DropForeignKey("dbo.Models", "Brand_ID", "dbo.Brands");
            DropForeignKey("dbo.Cars", "Brand_ID", "dbo.Brands");
            DropIndex("dbo.Favs", new[] { "User_ID" });
            DropIndex("dbo.Favs", new[] { "Car_ID" });
            DropIndex("dbo.Photos", new[] { "Car_ID" });
            DropIndex("dbo.Messages", new[] { "Conversations_ID" });
            DropIndex("dbo.Conversations", new[] { "Seller_ID" });
            DropIndex("dbo.Conversations", new[] { "Car_ID" });
            DropIndex("dbo.Conversations", new[] { "Buyer_ID" });
            DropIndex("dbo.Models", new[] { "Brand_ID" });
            DropIndex("dbo.Cars", new[] { "CarModel_ID" });
            DropIndex("dbo.Cars", new[] { "Brand_ID" });
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "CityName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Mail", c => c.String());
            DropColumn("dbo.Conversations", "Seller_ID");
            DropColumn("dbo.Conversations", "Car_ID");
            DropColumn("dbo.Conversations", "Buyer_ID");
            DropColumn("dbo.Cars", "CarModel_ID");
            DropColumn("dbo.Cars", "Brand_ID");
            DropColumn("dbo.Cars", "Type");
            DropColumn("dbo.Cars", "State");
            DropColumn("dbo.Cars", "Gearbox");
            DropColumn("dbo.Cars", "Fuel");
            DropColumn("dbo.Cars", "Drive");
            DropColumn("dbo.Cars", "Views");
            DropColumn("dbo.Cars", "Favs");
            DropColumn("dbo.Cars", "Phone");
            DropColumn("dbo.Cars", "City");
            DropColumn("dbo.Cars", "PostCode");
            DropColumn("dbo.Cars", "MainPhoto");
            DropColumn("dbo.Cars", "NoAcc");
            DropColumn("dbo.Cars", "ASO");
            DropColumn("dbo.Cars", "FirstOwner");
            DropColumn("dbo.Cars", "Desc");
            DropColumn("dbo.Cars", "Color");
            DropColumn("dbo.Cars", "bHP");
            DropColumn("dbo.Cars", "Engine");
            DropColumn("dbo.Cars", "Leasing");
            DropColumn("dbo.Cars", "VAT");
            DropColumn("dbo.Cars", "Country");
            DropTable("dbo.Favs");
            DropTable("dbo.Photos");
            DropTable("dbo.Messages");
            DropTable("dbo.Models");
            DropTable("dbo.Brands");
            RenameIndex(table: "dbo.Conversations", name: "IX_Users_ID", newName: "IX_User_ID");
            RenameColumn(table: "dbo.Conversations", name: "Users_ID", newName: "User_ID");
        }
    }
}
