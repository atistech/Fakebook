namespace Fakebook.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Son2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "Comment_ID", "dbo.Comments");
            DropForeignKey("dbo.Likes", "Post_ID", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "Comment_ID" });
            DropIndex("dbo.Likes", new[] { "Post_ID" });
            RenameColumn(table: "dbo.Likes", name: "Comment_ID", newName: "CommentID");
            RenameColumn(table: "dbo.Likes", name: "Post_ID", newName: "PostID");
            AlterColumn("dbo.Likes", "CommentID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Likes", "PostID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Likes", "PostID");
            CreateIndex("dbo.Likes", "CommentID");
            AddForeignKey("dbo.Likes", "CommentID", "dbo.Comments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "PostID", "dbo.Posts", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Likes", "CommentID", "dbo.Comments");
            DropIndex("dbo.Likes", new[] { "CommentID" });
            DropIndex("dbo.Likes", new[] { "PostID" });
            AlterColumn("dbo.Likes", "PostID", c => c.Guid());
            AlterColumn("dbo.Likes", "CommentID", c => c.Guid());
            RenameColumn(table: "dbo.Likes", name: "PostID", newName: "Post_ID");
            RenameColumn(table: "dbo.Likes", name: "CommentID", newName: "Comment_ID");
            CreateIndex("dbo.Likes", "Post_ID");
            CreateIndex("dbo.Likes", "Comment_ID");
            AddForeignKey("dbo.Likes", "Post_ID", "dbo.Posts", "ID");
            AddForeignKey("dbo.Likes", "Comment_ID", "dbo.Comments", "ID");
        }
    }
}
