using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
           return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANG Model)
        {
            if( ModelState.IsValid )
            {
                var kh = db.KHACHHANGs.FirstOrDefault(k => k.Taikhoan == Model.Taikhoan);
                if ( kh != null )
                {
                    ModelState.AddModelError("Taikhoan", "Tài khoản đã tồn tại");
                    return View();
                }
                db.KHACHHANGs.Add( Model );
                db.SaveChanges();
                return Redirect("DangNhap");
            }
            return View();
        }

        public ActionResult Dangnhap()
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult Dangnhap(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var u = db.KHACHHANGs.FirstOrDefault(k => k.Taikhoan == user.UserName && k.Matkhau == user.Password);
                if ( u == null)
                {
                    Session["Taikhoan"] = u;
                    ViewBag.ThongBao = " Đăng nhập Thành công";
                }
                else
                {
                    ModelState.AddModelError("Password","Tài khoản và mật khẩu không tồn tại");
                }
                return Redirect("~/");
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["Taikhoan"] = null;
            //return Redirect("Index", "SachOnline");
            return Redirect("I~/");
        }
    }
}