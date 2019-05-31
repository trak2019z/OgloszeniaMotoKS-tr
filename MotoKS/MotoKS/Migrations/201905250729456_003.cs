namespace MotoKS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cars", name: "Users_ID", newName: "User_ID");
            RenameIndex(table: "dbo.Cars", name: "IX_Users_ID", newName: "IX_User_ID");
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            AddColumn("dbo.Cars", "OC", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Registered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conversations", "User_ID", "dbo.Users");
            DropIndex("dbo.Conversations", new[] { "User_ID" });
            DropColumn("dbo.Cars", "Registered");
            DropColumn("dbo.Cars", "OC");
            DropTable("dbo.Conversations");
            RenameIndex(table: "dbo.Cars", name: "IX_User_ID", newName: "IX_Users_ID");
            RenameColumn(table: "dbo.Cars", name: "User_ID", newName: "Users_ID");
        }
    }
}
