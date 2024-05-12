
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO

{

    public class Menu_rulerDTO
    {

        #region 属性


        private int _Id = 0;
        /// <summary>
        ///序号
        /// </summary>
        [Display(Name = "编号")]
        public int Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }


        private DateTime _Createtime = DateTime.Now;
        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime Createtime
        {
            get { return this._Createtime; }
            set { this._Createtime = value; }
        }


        private string? _Username = "";
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名是必须")]
        public string? Username
        {
            get { return this._Username; }
            set { this._Username = value; }
        }

        private string? _Menuid = "";
        [Display(Name = "菜单ID")]
        [Required(ErrorMessage = "菜单ID是必须")]
        public string? Menuid
        {
            get { return this._Menuid; }
            set { this._Menuid = value; }
        }

        private int? _Managerid = 0;
        [Display(Name = "用户ID")]
        [Required(ErrorMessage = "用户ID是必须")]
        public int? Managerid
        {
            get { return this._Managerid; }
            set { this._Managerid = value; }
        }



        #endregion


    }
}