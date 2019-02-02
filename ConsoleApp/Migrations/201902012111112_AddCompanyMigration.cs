namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messagers",
                c => new
                    {
                        MessagerID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        TextMessage = c.String(),
                        RecepientId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessagerID)
                .ForeignKey("dbo.Recepients", t => t.RecepientId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RecepientId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Recepients",
                c => new
                    {
                        RecepientId = c.Int(nullable: false, identity: true),
                        PhoneRecepient = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.RecepientId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        PhoneUser = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messagers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messagers", "RecepientId", "dbo.Recepients");
            DropIndex("dbo.Messagers", new[] { "UserId" });
            DropIndex("dbo.Messagers", new[] { "RecepientId" });
            DropTable("dbo.Users");
            DropTable("dbo.Recepients");
            DropTable("dbo.Messagers");
        }
    }
}
