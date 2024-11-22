
using DemoGHang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace DemoGHang.Controllers
{
    public class AccountController : Controller
    {
        /// gọi class đại diện cho csdl ở đây
        private readonly GHDbContex _db;  // biến toàn cục, dùng chung cho toàn bộ class
        //tiem DI
        public AccountController(GHDbContex db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            return View();
        }

        //chức năng đăng kí
        public IActionResult DangKy() /// tạo ra view đang ki
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(Account acc)
        {
            try
            {
                //tạo mới 1 acc
                _db.Accounts.Add(acc);
                //khhi tạo acc thhafnh công thì đồng thời sẽ tạo 1 giỏ hàng
                GioHang gh = new GioHang()
                {
                    UserName = acc.UserName,
                    AccountId = acc.AccId

                };

                //thêm giỏ hàng

                _db.GioHangs.Add(gh);
                _db.SaveChanges();
                TempData["status"] = "Chúc mừng bạn đã tạo tài khoản thành công";
                return RedirectToAction("Login");

            }
            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }
        }

        //đăng nhậpp
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string password)//tham số nafyy là dữ liệu nhaajjp vào
        {
            //cheeck useer và pas đã nhập chưa
            if(userName == null || password == null)
            {

                return View();
            }
            //nếu mà nhập thì phaari check xem có tồn tại trong db k
            var acc = _db.Accounts.ToList().FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if(acc == null)
            {
                //return View(); 
                return Content("tài khoản or mk không chisnhh xác");
            }
            else
            {
                //lưu cái giữ liệu vừa mới login vào session với key là taikhoan 
                HttpContext.Session.SetString("taikhoan", userName);
                return RedirectToAction("Index", "SanPham");
            }

        }
    }
}
