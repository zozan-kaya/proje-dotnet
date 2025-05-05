using System.Diagnostics;
using kitapBlog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using projeDotnet.Models;
using projeDotnet.Models.Entities;

namespace projeDotnet.Controllers;

public class HomeController : Controller
{

    private readonly kitap_blog_dbContext db = new kitap_blog_dbContext();

    public HomeController(kitap_blog_dbContext _db)
    {
        db = _db;
    }
    public IActionResult Index()
    {
        ViewBag.active = "index";
        var kitaplar = (from x in db.Kitaplars
                        orderby x.Id descending
                        select new IndexVM
                        {
                            id = x.Id,
                            adi = x.Ad,
                            on_soz = x.Ozet,
                            yayinTarihi = x.YayinTarihi,
                            resim = x.Resim
                        }).Take(3).ToList();
        return View(kitaplar);
    }

    public IActionResult About()
    {
        ViewBag.active = "about";
        return View();
    }

    public IActionResult Blog()
    {
        ViewBag.active = "blog";
        var kitaplar = (from x in db.Kitaplars
                        orderby x.Id ascending
                        select new IndexVM
                        {
                            id = x.Id,
                            adi = x.Ad,
                            on_soz = x.Ozet,
                            yayinTarihi = x.YayinTarihi,
                            resim = x.Resim
                        }).ToList();
        return View(kitaplar);
    }


    [Route("/kitap/{kitapId}")]
    public IActionResult BlogPost(int kitapId)
    {
        ViewBag.active = "blog-post";
        var kitap = (from x in db.Kitaplars
                     where x.Id == kitapId
                     select new KitapVM
                     {
                         id = x.Id,
                         adi = x.Ad,
                         resim = x.Resim,
                         yazarAdi = x.Yazar,
                         yayinTarihi = x.YayinTarihi,
                         sayfaSayisi = x.SayfaSayisi,
                         ozet = x.Ozet,
                         yorum = x.Yorum
                     }).FirstOrDefault();

        return View(kitap);
    }

    public IActionResult Contact()
    {
        ViewBag.active = "contact";
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
