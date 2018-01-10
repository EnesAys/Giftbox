namespace GiftBox.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sekils", "Resim", c => c.Binary(storeType: "image"));
            AddColumn("dbo.AspNetUsers", "Resim", c => c.Binary(storeType: "image"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Resim");
            DropColumn("dbo.Sekils", "Resim");
        }
    }
}
