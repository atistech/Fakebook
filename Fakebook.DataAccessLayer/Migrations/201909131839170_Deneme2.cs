namespace Fakebook.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deneme2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Likes", "PostID", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "PostID" });
            DropIndex("dbo.Likes", new[] { "CommentID" });
            AlterColumn("dbo.Likes", "PostID", c => c.Guid());
            AlterColumn("dbo.Likes", "CommentID", c => c.Guid());
            CreateIndex("dbo.Likes", "PostID");
            CreateIndex("dbo.Likes", "CommentID");
            AddForeignKey("dbo.Likes", "CommentID", "dbo.Comments", "ID");
            AddForeignKey("dbo.Likes", "PostID", "dbo.Posts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Likes", "CommentID", "dbo.Comments");
            DropIndex("dbo.Likes", new[] { "CommentID" });
            DropIndex("dbo.Likes", new[] { "PostID" });
            AlterColumn("dbo.Likes", "CommentID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Likes", "PostID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Likes", "CommentID");
            CreateIndex("dbo.Likes", "PostID");
            AddForeignKey("dbo.Likes", "PostID", "dbo.Posts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "CommentID", "dbo.Comments", "ID", cascadeDelete: true);
        }
    }
}
