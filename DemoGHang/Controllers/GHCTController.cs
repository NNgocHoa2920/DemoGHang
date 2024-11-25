using DemoGHang.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoGHang.Controllers
{
    public class GHCTController : Controller
    {
        private readonly GHDbContex _db;
        public GHCTController(GHDbContex db) {_db = db;}
        public IActionResult Index()
        {
            var acc = HttpContext.Session.GetString("taikhoan"); //==username
            var getAcc = _db.Accounts.FirstOrDefault(x => x.UserName == acc);
            var giohang = _db.GioHangs.FirstOrDefault(x =>x.AccountId == getAcc.AccId);
            var ghctData = _db.GHCTs.Where(x => x.GioHangId == giohang.GioHangId).ToList();
            return View(ghctData);
        }
    }
}
