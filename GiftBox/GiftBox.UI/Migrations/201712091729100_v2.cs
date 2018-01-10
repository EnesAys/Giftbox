namespace GiftBox.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ciceks", "ResimAdi", c => c.String());
            AddColumn("dbo.Ciceks", "ResimPath", c => c.String());
            AddColumn("dbo.Cikolatas", "ResimAdi", c => c.String());
            AddColumn("dbo.Cikolatas", "ResimPath", c => c.String());
            AddColumn("dbo.AspNetUsers", "ResimAdi", c => c.String());
            AddColumn("dbo.AspNetUsers", "ResimPath", c => c.String());
            AddColumn("dbo.Fotografs", "ResimAdi", c => c.String());
            AddColumn("dbo.Fotografs", "ResimPath", c => c.String());
            DropColumn("dbo.Ciceks", "Resim");
            DropColumn("dbo.Cikolatas", "Resim");
            DropColumn("dbo.AspNetUsers", "Resim");
            DropColumn("dbo.Fotografs", "Resim");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fotografs", "Resim", c => c.Binary(storeType: "image"));
            AddColumn("dbo.AspNetUsers", "Resim", c => c.Binary(storeType: "image"));
            AddColumn("dbo.Cikolatas", "Resim", c => c.Binary(storeType: "image"));
            AddColumn("dbo.Ciceks", "Resim", c => c.Binary(storeType: "image"));
            DropColumn("dbo.Fotografs", "ResimPath");
            DropColumn("dbo.Fotografs", "ResimAdi");
            DropColumn("dbo.AspNetUsers", "ResimPath");
            DropColumn("dbo.AspNetUsers", "ResimAdi");
            DropColumn("dbo.Cikolatas", "ResimPath");
            DropColumn("dbo.Cikolatas", "ResimAdi");
            DropColumn("dbo.Ciceks", "ResimPath");
            DropColumn("dbo.Ciceks", "ResimAdi");
        }
    }
}
