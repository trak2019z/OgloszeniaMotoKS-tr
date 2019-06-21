namespace MotoKS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Conversations", "Seller_ID", "dbo.Users");
            DropIndex("dbo.Conversations", new[] { "Users_ID" });
            DropIndex("dbo.Conversations", new[] { "Seller_ID" });
            //DropColumn("dbo.Conversations", "Buyer_ID");
            RenameColumn(table: "dbo.Messages", name: "Conversations_ID", newName: "Conv_ID");
            //RenameColumn(table: "dbo.Conversations", name: "Users_ID", newName: "Buyer_ID");
            RenameIndex(table: "dbo.Messages", name: "IX_Conversations_ID", newName: "IX_Conv_ID");
            AddColumn("dbo.Cars", "Price_", c => c.Int(nullable: false));
            AddColumn("dbo.Conversations", "New", c => c.Boolean(nullable: false));
            AddColumn("dbo.Conversations", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Conversations", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Photos", "Main", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Cars", "Damaged", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Engine", c => c.Int(nullable: false));
            //DropColumn("dbo.Cars", "Price");
            DropColumn("dbo.Conversations", "Seller_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Conversations", "Seller_ID", c => c.Int());
            AddColumn("dbo.Cars", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Engine", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Damaged", c => c.Boolean(nullable: false));
            DropColumn("dbo.Photos", "Main");
            DropColumn("dbo.Conversations", "Count");
            DropColumn("dbo.Conversations", "Date");
            DropColumn("dbo.Conversations", "New");
            DropColumn("dbo.Cars", "Price_");
            RenameIndex(table: "dbo.Messages", name: "IX_Conv_ID", newName: "IX_Conversations_ID");
            RenameColumn(table: "dbo.Conversations", name: "Buyer_ID", newName: "Users_ID");
            RenameColumn(table: "dbo.Messages", name: "Conv_ID", newName: "Conversations_ID");
            AddColumn("dbo.Conversations", "Buyer_ID", c => c.Int());
            CreateIndex("dbo.Conversations", "Seller_ID");
            CreateIndex("dbo.Conversations", "Users_ID");
            AddForeignKey("dbo.Conversations", "Seller_ID", "dbo.Users", "ID");
        }
    }
}
