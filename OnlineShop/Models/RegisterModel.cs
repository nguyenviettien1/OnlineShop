using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật nhập")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không chính xác.")]
        [Required(ErrorMessage = "Yêu cầu xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Tỉnh thành")]
        public int ProvinceID { get; set; }
        [Display(Name = "Quận/Huyện")]
        public int DistrictID { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        public string Email { get; set; }
    }
}