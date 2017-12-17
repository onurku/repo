namespace gtsiparis_45.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resim : DbMigration
    {
        public override void Up()
        {
            AddColumn("gtadmin.Urun", "UrunGorseli", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("gtadmin.Urun", "UrunGorseli");
        }
    }
}
