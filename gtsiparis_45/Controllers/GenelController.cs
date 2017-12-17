using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gtsiparis_45;
using gtsiparis.Models;
using gtsiparis_45.Models;

namespace gtsiparis_45.Controllers
{
    public class GenelController : Controller
    {
        // GET: Genel
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            MenuViewModels viewModel = new MenuViewModels
            {
                // Here you do a database call to populate your menu items
                // This GetAllMenuItems method returns a list of MenuItem objects
                MenuItems = db.Menu.ToList(),

            };
            return PartialView("_UstMenu", viewModel);
            //return PartialView(viewModel);
        }

        //public ActionResult SagMenu()
        //{
        //    SiparisMenuView viewModel = new SiparisMenuView
        //    {
        //        // Here you do a database call to populate your menu items
        //        // This GetAllMenuItems method returns a list of MenuItem objects

        //        KategoriItems = db.Kategori.ToList(),
        //        UrunItems = db.Urun.ToList(),
        //    };
        //    return View(viewModel);

        //}
        
        public ActionResult UrunListesi(int? id)
        {
            IEnumerable<Urun> UrunListesi;
            if (id ==0)
            {
                UrunListesi = db.Urun.ToList();  
            }
            else
            {
                UrunListesi = (from b in db.Urun where b.Kategori_Id == id select b).ToList(); 
            }
            SiparisMenuView viewModel = new SiparisMenuView
            {
                KategoriItems = db.Kategori.ToList(),
                UrunItems = UrunListesi
            };
            return View(viewModel);
        }

        public ActionResult UrunGoster(int id)
        {
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return PartialView(urun);
        }




    }
}