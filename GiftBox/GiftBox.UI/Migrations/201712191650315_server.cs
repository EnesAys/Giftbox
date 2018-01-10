namespace GiftBox.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class server : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciceks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        ResimPath = c.String(),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RenkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Renks", t => t.RenkID, cascadeDelete: true)
                .Index(t => t.RenkID);
            
            CreateTable(
                "dbo.Renks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kutus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SekilID = c.Int(nullable: false),
                        RenkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Renks", t => t.RenkID, cascadeDelete: true)
                .ForeignKey("dbo.Sekils", t => t.SekilID, cascadeDelete: true)
                .Index(t => t.SekilID)
                .Index(t => t.RenkID);
            
            CreateTable(
                "dbo.Sekils",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tur = c.String(),
                        ResimPath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Siparis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KullaniciID = c.String(maxLength: 128),
                        CicekID = c.Int(),
                        CikolataID = c.Int(),
                        KutuID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ciceks", t => t.CicekID)
                .ForeignKey("dbo.Cikolatas", t => t.CikolataID)
                .ForeignKey("dbo.Kutus", t => t.KutuID)
                .ForeignKey("dbo.AspNetUsers", t => t.KullaniciID)
                .Index(t => t.KullaniciID)
                .Index(t => t.CicekID)
                .Index(t => t.CikolataID)
                .Index(t => t.KutuID);
            
            CreateTable(
                "dbo.Cikolatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        ResimPath = c.String(),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        DogumTarih = c.DateTime(nullable: false),
                        ResimPath = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Fotografs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Metin = c.String(),
                        KullaniciID = c.String(),
                        ResimPath = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Siparis", "KullaniciID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Fotografs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Siparis", "KutuID", "dbo.Kutus");
            DropForeignKey("dbo.Siparis", "CikolataID", "dbo.Cikolatas");
            DropForeignKey("dbo.Siparis", "CicekID", "dbo.Ciceks");
            DropForeignKey("dbo.Kutus", "SekilID", "dbo.Sekils");
            DropForeignKey("dbo.Kutus", "RenkID", "dbo.Renks");
            DropForeignKey("dbo.Ciceks", "RenkID", "dbo.Renks");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Fotografs", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Siparis", new[] { "KutuID" });
            DropIndex("dbo.Siparis", new[] { "CikolataID" });
            DropIndex("dbo.Siparis", new[] { "CicekID" });
            DropIndex("dbo.Siparis", new[] { "KullaniciID" });
            DropIndex("dbo.Kutus", new[] { "RenkID" });
            DropIndex("dbo.Kutus", new[] { "SekilID" });
            DropIndex("dbo.Ciceks", new[] { "RenkID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Fotografs");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Cikolatas");
            DropTable("dbo.Siparis");
            DropTable("dbo.Sekils");
            DropTable("dbo.Kutus");
            DropTable("dbo.Renks");
            DropTable("dbo.Ciceks");
        }
    }
}
