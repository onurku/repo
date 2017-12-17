namespace gtsiparis_45.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "gtadmin.Stok",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrunId = c.Int(),
                        SonStok = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Miktar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GirdiCikti = c.Boolean(nullable: false),
                        Tarih = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.Urun", t => t.UrunId)
                .Index(t => t.UrunId);
            
            AddColumn("gtadmin.Urun", "StokId", c => c.Int());
            CreateIndex("gtadmin.Urun", "StokId");
            AddForeignKey("gtadmin.Urun", "StokId", "gtadmin.Stok", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("gtadmin.Stok", "UrunId", "gtadmin.Urun");
            DropForeignKey("gtadmin.Urun", "StokId", "gtadmin.Stok");
            DropIndex("gtadmin.Stok", new[] { "UrunId" });
            DropIndex("gtadmin.Urun", new[] { "StokId" });
            DropColumn("gtadmin.Urun", "StokId");
            DropTable("gtadmin.Stok");
        }
    }
}
