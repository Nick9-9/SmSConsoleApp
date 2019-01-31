namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mesasages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSender = c.Int(nullable: false),
                        RecepientPhone = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        TextMessage = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recepients", t => t.RecepientPhone, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdSender, cascadeDelete: true)
                .Index(t => t.IdSender)
                .Index(t => t.RecepientPhone);
            
            CreateTable(
                "dbo.Recepients",
                c => new
                    {
                        IdRecepeint = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.IdRecepeint);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdSender = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.IdSender);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mesasages", "IdSender", "dbo.Users");
            DropForeignKey("dbo.Mesasages", "RecepientPhone", "dbo.Recepients");
            DropIndex("dbo.Mesasages", new[] { "RecepientPhone" });
            DropIndex("dbo.Mesasages", new[] { "IdSender" });
            DropTable("dbo.Users");
            DropTable("dbo.Recepients");
            DropTable("dbo.Mesasages");
        }
    }
}
