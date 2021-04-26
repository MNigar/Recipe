namespace RecipeDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                        CreatedUserId = c.Int(nullable: false),
                        ModifiedUserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        UserDAO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserDAO_Id)
                .Index(t => t.UserDAO_Id);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ingridients = c.String(maxLength: 200),
                        Quantity = c.String(),
                        Description = c.String(maxLength: 200),
                        Status = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedUserId = c.Int(nullable: false),
                        ModifiedUserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedUserId = c.Int(nullable: false),
                        ModifiedUserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Menu");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 200),
                        CreatedUserId = c.Int(nullable: false),
                        ModifiedUserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Recipe", "UserId", "dbo.User");
            DropForeignKey("dbo.Category", "UserDAO_Id", "dbo.User");
            DropForeignKey("dbo.Recipe", "CategoryId", "dbo.Category");
            DropIndex("dbo.Recipe", new[] { "UserId" });
            DropIndex("dbo.Recipe", new[] { "CategoryId" });
            DropIndex("dbo.Category", new[] { "UserDAO_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Recipe");
            DropTable("dbo.Category");
        }
    }
}
