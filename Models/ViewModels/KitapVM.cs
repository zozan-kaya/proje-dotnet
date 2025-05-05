namespace kitapBlog.Models.ViewModels;

public class KitapVM
{
    public uint id { get; set; }
    public string adi { get; set; }
    public string yazarAdi { get; set; }
    public int sayfaSayisi { get; set; }
    public string resim { get; set; }
    public int yayinTarihi { get; set; }
    public string ozet { get; set; }
    public string yorum { get; set; }
}