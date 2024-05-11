using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.DTO
{
    public class UserDTO   {
       public UserDTO(){
       }
        
        
        private int _Id = 0;
        [Display(Name = "Id")]
        //[Required(ErrorMessage = "Id是必须")]
        public int Id
        {
        get { return this._Id; }
        set { this._Id = value; }
        }
        private string? _Username = "";
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名是必须的")]
        [RegularExpression("^[a-zA-Z][a-zA-Z0-9]{4,20}$", ErrorMessage = "用户名必须是数字字母组合的4-20个长度的字符")]
        public string? Username
        {
        get { return this._Username; }
        set { this._Username = value; }
        }
        private string? _Email = "";
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "错误的邮件地址")]
        public string? Email
        {
        get { return this._Email; }
        set { this._Email = value; }
        }
        private string? _Mobile = "";
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "手机号码必须是11位数字")]
        [Display(Name = "手机")]
        public string? Mobile
        {
        get { return this._Mobile; }
        set { this._Mobile = value; }
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
         //[Required(ErrorMessage = "密码是必须的,长度为6-20")]
        [MinLength(2, ErrorMessage = "昵称的长度为2-20")]
        [MaxLength(20, ErrorMessage = "昵称的长度为2-20")]
        public string? Nickname
        {
        get { return this._Nickname; }
        set { this._Nickname = value; }
        }
        private string? _Headerpic = "";
        [Display(Name = "头像")]

        public string? Headerpic
        {
        get { return this._Headerpic; }
        set { this._Headerpic = value; }
        }
        private string? _Sex = "";
        [Display(Name = "性别")]
        public string? Sex
        {
        get { return this._Sex; }
        set { this._Sex = value; }
        } 
        private string? _Openid = "";
        [Display(Name = "Openid")]
        [MaxLength(128, ErrorMessage = "OpenId的长度不能大于128个字符")]

        public string? Openid
        {
        get { return this._Openid; }
        set { this._Openid = value; }
        }
         
         
         
         
        
        private string? _Intro = "";
        [Display(Name = "简介")]
        public string? Intro
        {
        get { return this._Intro; }
        set { this._Intro = value; }
        }
         
        private int _State = 0;
        [Display(Name = "状态正常")]
        public int State
        {
        get { return this._State; }
        set { this._State = value; }
        }
       
        private DateTime _Lastlogindatetime = DateTime.Now;
        [Display(Name = "最后登录")]
        public DateTime Lastlogindatetime
        {
        get { return this._Lastlogindatetime; }
        set { this._Lastlogindatetime = value; }
        }
        
        private DateTime _Createtime = DateTime.Now;
        [Display(Name = "创建时间")]
        public DateTime Createtime
        {
        get { return this._Createtime; }
        set { this._Createtime = value; }
        }
        
       
        
        
            
        private DateTime _Updatetime = DateTime.Now;
        [Display(Name = "更新时间")]
        public DateTime Updatetime
        {
        get { return this._Updatetime; }
        set { this._Updatetime = value; }
        }
        private int _Usertype = 0;
        [Display(Name = "用户类型")]
        public int Usertype
        {
        get { return this._Usertype; }
        set { this._Usertype = value; }
        }
        private string? _Name = "";
        [Display(Name = "姓名")]
        public string? Name
        {
        get { return this._Name; }
        set { this._Name = value; }
        }

        
   }
}
