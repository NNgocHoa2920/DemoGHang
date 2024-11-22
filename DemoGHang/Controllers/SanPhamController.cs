using DemoGHang.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoGHang.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly GHDbContex _db;
        public SanPhamController(GHDbContex db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //lấy giá trị sessioon có tên đã đc lưu
            var session = HttpContext.Session.GetString("taikhoan");  // session = username của account vừa đăng  nhâp
            if (session == null)
            {
                TempData["mess"] = "Chưa đăng nhập thì tao không cho xem";
                return RedirectToAction("Login","Account");
            }
            else
            {
                ViewData["mess"] = $"Mời {session} xem sản phẩm";
                var list = _db.SanPhams.ToList();
                return View(list);
            }    
            return View();
        }
    }
}
