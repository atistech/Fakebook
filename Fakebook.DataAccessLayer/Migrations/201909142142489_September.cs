namespace Fakebook.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class September : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        TextContent = c.String(),
                        Status = c.Int(),
                        CreatedComputerName = c.String(),
                        CreatedIP = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedADUserName = c.String(),
                        ModifiedComputerName = c.String(),
                        ModifiedIP = c.String(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedADUserName = c.String(),
                        Comment_ID = c.Guid(),
                        Post_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.Comment_ID)
                .ForeignKey("dbo.Posts", t => t.Post_ID)
                .Index(t => t.Comment_ID)
                .Index(t => t.Post_ID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        OwnerID = c.Guid(),
                        ItemID = c.Guid(),
                        Status = c.Int(),
                        CreatedComputerName = c.String(),
                        CreatedIP = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedADUserName = c.String(),
                        ModifiedComputerName = c.String(),
                        ModifiedIP = c.String(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedADUserName = c.String(),
                        Comment_ID = c.Guid(),
                        Post_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.Comment_ID)
                .ForeignKey("dbo.Posts", t => t.Post_ID)
                .Index(t => t.Comment_ID)
                .Index(t => t.Post_ID);
            
            CreateTable(
                "dbo.CoverImages",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Status = c.Int(),
                        CreatedComputerName = c.String(),
                        CreatedIP = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedADUserName = c.String(),
                        ModifiedComputerName = c.String(),
                        ModifiedIP = c.String(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedADUserName = c.String(),
                        Image_ID = c.Guid(),
                        User_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.Image_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Image_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Base64 = c.String(nullable: false, storeType: "ntext"),
                        Status = c.Int(),
                        CreatedComputerName = c.String(),
                        CreatedIP = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedADUserName = c.String(),
                        ModifiedComputerName = c.String(),
                        ModifiedIP = c.String(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedADUserName = c.String(),
                        User_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Role = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Status = c.Int(),
                        CreatedComputerName = c.String(),
                        CreatedIP = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedADUserName = c.String(),
                        ModifiedComputerName = c.String(),
                        ModifiedIP = c.String(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedADUserName = c.String(),
                        User_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PostDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TextContent = c.String(nullable: false),
                        Status = c.Int(),
                        CreatedComputerName = c.String(),
                        CreatedIP = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedADUserName = c.String(),
                        ModifiedComputerName = c.String(),
                        ModifiedIP = c.String(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedADUserName = c.String(),
                        ContentImage_ID = c.Guid(),
                        User_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.ContentImage_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.ContentImage_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.ProfileImages",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Status = c.Int(),
                        CreatedComputerName = c.String(),
                        CreatedIP = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedADUserName = c.String(),
                        ModifiedComputerName = c.String(),
                        ModifiedIP = c.String(),
                        ModifiedBy = c.Guid(),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedADUserName = c.String(),
                        Image_ID = c.Guid(),
                        User_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.Image_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Image_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileImages", "User_ID", "dbo.Users");
            DropForeignKey("dbo.ProfileImages", "Image_ID", "dbo.Images");
            DropForeignKey("dbo.CoverImages", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Likes", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "ContentImage_ID", "dbo.Images");
            DropForeignKey("dbo.Comments", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.Images", "User_ID", "dbo.Users");
            DropForeignKey("dbo.CoverImages", "Image_ID", "dbo.Images");
            DropForeignKey("dbo.Likes", "Comment_ID", "dbo.Comments");
            DropForeignKey("dbo.Comments", "Comment_ID", "dbo.Comments");
            DropIndex("dbo.ProfileImages", new[] { "User_ID" });
            DropIndex("dbo.ProfileImages", new[] { "Image_ID" });
            DropIndex("dbo.Posts", new[] { "User_ID" });
            DropIndex("dbo.Posts", new[] { "ContentImage_ID" });
            DropIndex("dbo.Users", new[] { "User_ID" });
            DropIndex("dbo.Images", new[] { "User_ID" });
            DropIndex("dbo.CoverImages", new[] { "User_ID" });
            DropIndex("dbo.CoverImages", new[] { "Image_ID" });
            DropIndex("dbo.Likes", new[] { "Post_ID" });
            DropIndex("dbo.Likes", new[] { "Comment_ID" });
            DropIndex("dbo.Comments", new[] { "Post_ID" });
            DropIndex("dbo.Comments", new[] { "Comment_ID" });
            DropTable("dbo.ProfileImages");
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.Images");
            DropTable("dbo.CoverImages");
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
        }
    }
}
