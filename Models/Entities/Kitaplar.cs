using System;
using System.Collections.Generic;

namespace projeDotnet.Models.Entities
{
    public partial class Kitaplar
    {
        public uint Id { get; set; }
        public string Ad { get; set; } = null!;
        public string Yazar { get; set; } = null!;
        public ushort SayfaSayisi { get; set; }
        public short YayinTarihi { get; set; }
        public string Ozet { get; set; } = null!;
        public string Yorum { get; set; } = null!;
        public string Resim { get; set; } = null!;
    }
}
