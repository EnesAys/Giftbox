namespace GiftBox.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sekils", "ResimPath", c => c.String());
            DropColumn("dbo.Ciceks", "ResimAdi");
            DropColumn("dbo.Sekils", "Resim");
            DropColumn("dbo.Cikolatas", "ResimAdi");
            DropColumn("dbo.AspNetUsers", "ResimAdi");
            DropColumn("dbo.Fotografs", "ResimAdi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fotografs", "ResimAdi", c => c.String());
            AddColumn("dbo.AspNetUsers", "ResimAdi", c => c.String());
            AddColumn("dbo.Cikolatas", "ResimAdi", c => c.String());
            AddColumn("dbo.Sekils", "Resim", c => c.Binary(storeType: "image"));
            AddColumn("dbo.Ciceks", "ResimAdi", c => c.String());
            DropColumn("dbo.Sekils", "ResimPath");
        }
    }
}
