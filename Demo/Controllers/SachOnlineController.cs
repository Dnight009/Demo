using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using System.Dynamic;

namespace Demo.Controllers
{
    public class SachOnlineController : Controller
    {
        Model1 db = new Model1();

        // GET: SachOnline
        public ActionResult Index(int? page)
        {
            var lstSaches = db.SACHes.OrderBy(s => s.Masach);
            int pageNumber = (page) ?? 1;
            int pageSize = 9;
            ViewBag.TieuDe = "SachMoi";
            return View(lstSaches.ToPagedList(pageNumber, pageSize));
            
        }

        public ActionResult ChuDePartial()
        {
            var lst = db.CHUDEs.ToList();
            return PartialView(lst);
        }


        public ActionResult NhaXuatBanPartial()
        {
            var lst = db.NHAXUATBANs.ToList();
            return PartialView(lst);
        }

        public ActionResult ChitietSach(int Masach )
        {
            var sach = db.SACHes.FirstOrDefault(s => s.Masach==Masach);

            return View(sach);
        }

        public ActionResult MenuPartial()
        {
            dynamic model = new ExpandoObject();
            model.CHUDEs = db.CHUDEs.ToList();
            model.NHAXUATBANs = db.NHAXUATBANs.ToList();
            return PartialView(model);
        }

        public ActionResult SachTheoChuDe(int MaCD, int? page)
        {

            var lstSaches = db.SACHes.Where(s => s.MaCD == MaCD).OrderBy(s => s.Masach).ToList();
            int pageNumber = (page) ?? 1;
            int pageSize = 9;
            ViewBag.TieuDe = "SÁCH THEO CHỦ ĐỀ";
            return View("Index", lstSaches.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult SachTheoNXB(int MaNXB, int? page)
        {
            var lstSaches = db.SACHes.Where(s => s.MaNXB == MaNXB).OrderBy(s => s.Masach).ToList();
            int pageNumber = (page) ?? 1;
            int pageSize = 9;
            ViewBag.TieuDe = "SÁCH THEO NHÀ XUẤT BẢN";
            return View("Index", lstSaches.ToPagedList(pageNumber, pageSize));
        }
    }
}