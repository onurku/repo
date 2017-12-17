namespace gtsiparis_45.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grd : DbMigration
    {
        public override void Up()
        {

            AlterColumn("gtadmin.Siparis", "OnayKullaniciId", c => c.Int());
            AlterColumn("gtadmin.Kategori", "CreatedTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            CreateIndex("gtadmin.Siparis", "OnayKullaniciId");
            AddForeignKey("gtadmin.Siparis", "OnayKullaniciId", "gtadmin.Kullanici", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("gtadmin.Siparis", "OnayKullaniciId", "gtadmin.Kullanici");
            DropIndex("gtadmin.Siparis", new[] { "OnayKullaniciId" });
            AlterColumn("gtadmin.Kategori", "CreatedTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("gtadmin.Siparis", "OnayKullaniciId", c => c.Int(nullable: false));
            DropTable("gtadmin.__MigrationHistory");
        }
    }
}
