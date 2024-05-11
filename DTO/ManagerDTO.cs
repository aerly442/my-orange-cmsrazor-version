using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.DTO
{
    public class ManagerDTO
    {
        #region 属性


        /// <summary>
        ///序号
        /// </summary>
        /// 
        // [Column]
        [Display(Name = "编号")]
        public int Id { get; set; } = 0;

        private string _username = "";
        [Required(ErrorMessage = "用户名是必须的，为数字字母组合的4-20个长度的字符")]
        [RegularExpression("^[a-zA-Z][a-zA-Z0-9]{4,20}$", ErrorMessage = "用户名必须是数字字母组合的4-20个长度的字符")]
        [Display(Name = "用户名")]
        public string username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        private string _password = "";
        [Required(ErrorMessage = "密码是必须的,长度为6-20")]
        [MinLength(6, ErrorMessage = "密码是必须的,长度为6-20")]
        [MaxLength(20, ErrorMessage = "密码是必须的,长度为6-20")]
        [Display(Name = "密码")]
        public string password
        {
            get { return this._password; }
            set { this._password = value; }
        }


 

        private string _name = "";
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名是必须的")]
        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private string _tel = "";
        [Display(Name = "联系方式")]
        [Required(ErrorMessage = "联系方式是必须的")]
        public string tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        private string _depart = "";
        [Display(Name = "部门")]
        [Required(ErrorMessage = "部门是必须的")]
        public string depart
        {
            get { return this._depart; }
            set { this._depart = value; }
        }

        private int _power = 0;
        [Display(Name = "用户权限")]
        public int power
        {
            get { return this._power; }
            set { this._power = value; }
        }

        private DateTime? _lastlogindatetime = DateTime.Now;
        [Display(Name = "登录时间")]
        public DateTime? lastlogindatetime
        {
            get { return this._lastlogindatetime; }
            set { this._lastlogindatetime = value; }
        }

        private string? _lastloginip = "";
        [Display(Name = "登录IP")]
        public string? lastloginip
        {
            get { return this._lastloginip; }
            set { this._lastloginip = value; }
        }

        private DateTime _createtime = DateTime.Now;
        /// <summary>
        ///创建时间
        /// </summary>
        /// 
        [Display(Name="创建时间")]
        public DateTime createtime
        {
            get { return this._createtime; }
            set { this._createtime = value; }
        }





        #endregion
    }
}
