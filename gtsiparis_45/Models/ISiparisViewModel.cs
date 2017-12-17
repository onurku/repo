﻿using System.Collections.Generic;

namespace gtsiparis_45.Models
{
    public interface SiparisViewModel
    {
        IEnumerable<Kategori> KategoriItems { get; set; }
        IEnumerable<Siparis> SiparisItems { get; set; }
        IEnumerable<Urun> UrunItems { get; set; }
    }
}