namespace GiftBox.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fotografs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Fotografs", new[] { "User_Id" });
            AddColumn("dbo.Siparis", "Metin", c => c.String());
            AddColumn("dbo.Siparis", "ResimPath", c => c.String());
            AddColumn("dbo.Siparis", "Adres", c => c.String());
            AddColumn("dbo.Siparis", "TeslimTarih", c => c.DateTime(nullable: false));
            DropTable("dbo.Fotografs");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Siparis", "TeslimTarih");
            DropColumn("dbo.Siparis", "Adres");
            DropColumn("dbo.Siparis", "ResimPath");
            DropColumn("dbo.Siparis", "Metin");
            CreateIndex("dbo.Fotografs", "User_Id");
            AddForeignKey("dbo.Fotografs", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
