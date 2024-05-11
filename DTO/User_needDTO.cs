
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO

{

    public class User_needDTO
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


        private DateTime? _Updatetime = DateTime.Now;
        [Display(Name = "更新时间")]
        [Required(ErrorMessage = "更新时间是必须")]
        public DateTime? Updatetime
        {
            get { return this._Updatetime; }
            set { this._Updatetime = value; }
        }

        private string? _Title = "";
        [Display(Name = "标题")]
        [Required(ErrorMessage = "标题是必须")]
        public string? Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }

        private string? _Note = "";
        [Display(Name = "备注")]
        //[Required(ErrorMessage = "备注是必须")]
        public string? Note
        {
            get { return this._Note; }
            set { this._Note = value; }
        }

        private string? _Email = "";
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email是必须")]
        public string? Email
        {
            get { return this._Email; }
            set { this._Email = value; }
        }

        private int? _State = 0;
        [Display(Name = "状态")]
        [Required(ErrorMessage = "状态是必须")]
        public int? State
        {
            get { return this._State; }
            set { this._State = value; }
        }

        private int? _Pay_type = 0;
        [Display(Name = "支付类型")]
        //[Required(ErrorMessage = "支付类型是必须")]
        public int? Pay_type
        {
            get { return this._Pay_type; }
            set { this._Pay_type = value; }
        }



        #endregion


    }
}