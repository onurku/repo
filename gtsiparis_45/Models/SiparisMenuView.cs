using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace gtsiparis_45.Models
{
    public class SiparisMenuView
    {
        public IEnumerable<Kategori> KategoriItems { get; set; }
        public IEnumerable<Urun> UrunItems { get; set; }
    }
}