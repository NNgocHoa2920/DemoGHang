using System.ComponentModel.DataAnnotations;

namespace DemoGHang.Models
{
    public class Account
    {
        //nếu khhoas chính ID =>> sẽ tự hiểu đây KEY

        [Key]
        public Guid AccId { get; set; }
        public string Name { get; set; }
        public string UserName {  get; set; }
        public string Password { get; set; }
        public DateTime NgaySinh { get; set; }
        [RegularExpression("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$",
                     ErrorMessage = "số điên thoại phải đúng format xxx-xxx-xxxx")]  //xxx-xxx-xxxx
        public string SDT { get; set; }

        public GioHang? GioHang { get; set; }
        //dấu ? thể hiện rằng được phép null hoặc k
        //Trừ khóa chhisnh và 1 số thuộc tính bắt buộc phải nhập thhif các bạn nên cho dấu ? hết

    }
}
