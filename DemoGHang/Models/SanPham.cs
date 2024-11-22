using System.ComponentModel.DataAnnotations;

namespace DemoGHang.Models
{
    public class SanPham
    {
        [Key]
        public Guid SanPhamId { get; set; }
        public string SanPhamName { get; set; }
        public string Price {  get; set; }
        public string MoTa {  get; set; }
        public List<GHCT> GHCTs { get; set; }
    }
}
