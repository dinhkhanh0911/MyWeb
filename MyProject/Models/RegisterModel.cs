using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class RegisterModel
    {
        [Key]
        public int id { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Hãy nhập tài khoản")]
        
        public string userName { set; get; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Hãy nhập tên")]
        public string fullName { set; get; }

        [Display(Name = "Tuổi")]
        [Required(ErrorMessage = "Hãy nhập tuổi")]
        public int age { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required (ErrorMessage = "Hãy nhập mật khẩu")]
        [StringLength ( 20,MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu từ sáu trở nên")]
        public string Password { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string confirmPassword { set; get; }

    }
}