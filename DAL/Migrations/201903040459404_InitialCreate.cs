namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        UserFullName = c.String(),
                        UserID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StartDateAndTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        Duration = c.Int(),
                        Description = c.String(),
                        OtherDetails = c.String(),
                        InviteCount = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        isPublic = c.Boolean(nullable: false),
                        UserFullName = c.String(),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Invites",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EventID, t.Email });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Invites");
            DropTable("dbo.Events");
            DropTable("dbo.Comments");
        }
    }
}
