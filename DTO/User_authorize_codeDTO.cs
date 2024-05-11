using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.DTO
{
    public class User_authorize_codeDTO   {
 
          
        #region  dto 属性
        private int _Id = 0;
        [Display(Name = "编号")]
        
        public int Id
        {
        get { return this._Id; }
        set { this._Id = value; }
        }
        

        private string? _Nickname = "";
        [Display(Name = "昵称")]
        public string? Nickname
        {
        get { return this._Nickname; }
        set { this._Nickname = value; }
        }
        private string? _Openid = "";
        [Display(Name = "OpenId")]
        public string? Openid
        {
        get { return this._Openid; }
        set { this._Openid = value; }
        }
        private string? _Mobile = "";
        [Display(Name = "手机")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "手机必须是11位的数字")]
        public string? Mobile
        {
        get { return this._Mobile; }
        set { this._Mobile = value; }
        }
        private string? _Email = "";
        [Display(Name = "邮件")]
        public string? Email
        {
        get { return this._Email; }
        set { this._Email = value; }
        }
        private string? _Code = "";
        [Display(Name = "验证码")]
        [Required(ErrorMessage = "验证码是必须的，必须为数字字母组合的6个长度的字符")]
        [RegularExpression("^[a-zA-Z0-9]{6}$", ErrorMessage = "用户名必须是数字字母组合的6个长度的字符")] 
        public string? Code
        {
        get { return this._Code; }
        set { this._Code = value; }
        }
        private DateTime _Sendtime = DateTime.Now;
        [Display(Name = "发送时间")]
        public DateTime Sendtime
        {
        get { return this._Sendtime; }
        set { this._Sendtime = value; }
        }
        private int _Sendstate = 0;
        [Display(Name = "发送状态")]
        public int Sendstate
        {
        get { return this._Sendstate; }
        set { this._Sendstate = value; }
        }
        private int _State = 0;
        [Display(Name = "状态")]
        public int State
        {
        get { return this._State; }
        set { this._State = value; }
        }
        private DateTime _Createtime = DateTime.Now;
        [Display(Name = "创建时间")]
        public DateTime Createtime
        {
        get { return this._Createtime; }
        set { this._Createtime = value; }
        }
        private string? _Messagetype = "";
        [Display(Name = "信息类型")]
        public string? Messagetype
        {
        get { return this._Messagetype; }
        set { this._Messagetype = value; }
        }


        #endregion

   }
}
