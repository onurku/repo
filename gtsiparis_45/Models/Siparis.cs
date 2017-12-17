namespace gtsiparis_45
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gtadmin.Siparis")]
    public partial class Siparis
    {
        [Key]
        public int Id { get; set; }

        public decimal Miktar { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime Tarih { get; set; }

        public bool Onay { get; set; }

        [DisplayName("İade Edildi mi?")]
        public bool Iade { get; set; }

        [DisplayName("Kullanıcı")]
        public int? Kullanici_Id { get; set; }
        public virtual Kullanici Kullanici { get; set; }

        [DisplayName("Onaylayan Kullanıcı")]
        public int? OnayKullaniciId { get; set; }
        public virtual Kullanici Onaylayan { get; set; }

        [DisplayName("Ürün")]
        public int? Urun_Id { get; set; }

        

        

        public virtual Urun Urun { get; set; }


    }
}
