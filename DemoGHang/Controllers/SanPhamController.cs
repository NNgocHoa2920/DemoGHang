using DemoGHang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

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
            ////lấy giá trị sessioon có tên đã đc lưu
            //var session = HttpContext.Session.GetString("taikhoan");  // session = username của account vừa đăng  nhâp
            //if (session == null)
            //{
            //    TempData["mess"] = "Chưa đăng nhập thì tao không cho xem";
            //    return RedirectToAction("Login","Account");
            //}
            //else
            //{
            //    ViewData["mess"] = $"Mời {session} xem sản phẩm";
                var list = _db.SanPhams.ToList();
                return View(list);
            //}    
            //return View();
        }

       //THÊM SANPHAM
       public IActionResult Create()  // taO RA VIEW CREATE
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham sp)
        {
            _db.SanPhams.Add(sp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xem chi tiết sp
        public IActionResult Details(Guid idSanPham)
        {
            //tìm sản phẩm muốn xem
            var a   = _db.SanPhams.Find(idSanPham);
            return View(a);
        }

        //thêm sản phẩm vào giỏ hàng
        //xử lí cộng dồn nếu như sản phầm bị trùng

        public IActionResult AddToCart(Guid ID, int soLuong) // id: id san phẩm đc add
        {
            //lấy ra user name tương ứng vs giỏ hàng
            var acc = HttpContext.Session.GetString("taikhoan"); // username đã đc lưu vào session
            if(acc == null)
            {
                TempData["mess"] = "Đăng nhập đi bạn ơi";
                return RedirectToAction("Login", "Account");

            }
            //lấy thông tin ủa account vừa ms đăng nhập => lấy toàn bộ đối tượng
            var getAcc = _db.Accounts.FirstOrDefault(x => x.UserName == acc);
            //lấy giỏ hàng tương ứng
            var gioHang = _db.GioHangs.FirstOrDefault(x => x.AccountId == getAcc.AccId);
            if (gioHang == null) 
            {
                return Content("chua có giỏ hàng");
            }

            //lấy toàn bộ sản phrm trong ghct của acc
            var lstGHCT = _db.GHCTs.Where(x => x.GioHangId == gioHang.GioHangId).ToList();

            //xử lí cộng dồn
            bool check = false;
            Guid idGHCT = Guid.NewGuid();
            foreach(var item in lstGHCT)
            {
                if(item.SanPhamId == ID) // nếu id trong giỏ hàng trùng vs id của sanpham vừa đc add
                {
                    check = true;
                    idGHCT = item.ID;
                    break;
                }    
            }
            //nếu sản phẩm đc add chưa tồn tại trong gỏ hàng
            if(!check)
            {
                //tạo ra 1 ghct với sp đó
                GHCT ghct = new GHCT()
                {
                    SanPhamId = ID,
                    GioHangId = gioHang.GioHangId,
                    SoLuong = soLuong,
                };
                _db.GHCTs.Add(ghct);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                var ghctUpdate = _db.GHCTs.FirstOrDefault(x => x.ID == idGHCT);
                ghctUpdate.SoLuong = ghctUpdate.SoLuong + soLuong;
                _db.GHCTs.Update(ghctUpdate);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
        }


    }
}
