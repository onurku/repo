namespace gtsiparis_45
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gtadmin.Urun")]
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            Siparisler = new HashSet<Siparis>();
            Stoklar = new HashSet<Stok>();
        } 

        public int Id { get; set; }

        public string Adi { get; set; }

        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }

        [DataType(DataType.Currency)]
        public decimal Maliyet { get; set; }

        [DataType(DataType.Currency)]
        public decimal Fiyat { get; set; }

        [DisplayName("Başlangıç Tarihi")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Baslangic { get; set; }

        [DisplayName("Bitiş Tarihi")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Bitis { get; set; }

        public bool Aktif { get; set; }

        [DisplayName("Birim")]
        public int? Birim_Id { get; set; }
        public virtual Birim Birim { get; set; }

        [DisplayName("Stok")]
        public int? StokId { get; set; }
        public virtual Stok Stok { get; set; }

        [DisplayName("Grup")]
        public int? Grup_Id { get; set; }
        public virtual Grup Grup { get; set; }

        [DisplayName("Kategori")]
        public int? Kategori_Id { get; set; }
        public virtual Kategori Kategori { get; set; }

        [DisplayName("Sorumlu")]
        public int? Sorumlu_Id { get; set; }
        public virtual Kullanici Sorumlu { get; set; }

        [DisplayName("Üretici")]
        public int? Uretici_Id { get; set; }
        public virtual Kullanici Uretici { get; set; }

        [DisplayName("Ürün Görseli")]
        public byte[] UrunGorseli { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparisler { get; set; }

        public virtual ICollection<Stok> Stoklar { get; set; }
    }
}
