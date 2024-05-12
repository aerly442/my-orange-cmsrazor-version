using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.DTO
{
    public class FrontUserDTO   {
       public FrontUserDTO(){
       }
        
        
  
        private string? _Email = "";
        [Display(Name = "Email")]
        [Required(ErrorMessage = "邮箱地址是必须的")]
        [EmailAddress(ErrorMessage = "错误的邮箱地址")]
        public string? Email
        {
        get { return this._Email; }
        set { this._Email = value; }
        }
         
        private string? _Password = "";
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码是必须的")]
        [MinLength(6, ErrorMessage = "密码的长度为6-20")]
        [MaxLength(20, ErrorMessage = "密码的长度为6-20")]
        public string? Password
        {
        get { return this._Password; }
        set { this._Password = value; }
        }
        private string? _Nickname = "";
        [Display(Name = "昵称")]
        [Required(ErrorMessage = "昵称是必须的,长度为2-20")]
        [MinLength(2, ErrorMessage = "昵称的长度为2-20")]
        [MaxLength(20, ErrorMessage = "昵称的长度为2-20")]
        public string? Nickname
        {
        get { return this._Nickname; }
        set { this._Nickname = value; }
        }


        private string? _RePassword= "";
        [Display(Name = "密码")]
        [Required(ErrorMessage = "重复密码是必须的")]
        [MinLength(6, ErrorMessage = "重复密码的长度为6-20")]
        [MaxLength(20, ErrorMessage = "重复密码的长度为6-20")]
        public string? RePassword
        {
        get { return this._RePassword; }
        set { this._RePassword = value; }
        }
         

        
   }
}
