using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoGHang.Models
{
    public class GioHang
    {
        [Key]
        public Guid GioHangId { get; set; }
        public string UserName { get; set; }
        public Account? Account { get; set; }

        [ForeignKey("Account")]
        public Guid? AccountId { get; set; }
        public List<GHCT> GHCTs { get; set; }
    }
}
