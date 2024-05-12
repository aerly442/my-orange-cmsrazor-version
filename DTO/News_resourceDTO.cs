
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    
	public class News_resourceDTO
	{
 
		#region 属性
		
		
		private int _Id = 0;
        /// <summary>
        ///序号
        /// </summary>
        [Display(Name = "编号")]
        public int Id
        {
			set { this._Id = value; }
		}


		private DateTime _Createtime = DateTime.Now;
        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime Createtime
        {
			set { this._Createtime = value; }
		}
		
		
	    private string? _Resource ="";
		[Required(ErrorMessage = "内容是必须")]
		public string? Resource
        private string? _Note ="";
		//[Required(ErrorMessage = "备注是必须")]
		public string? Note
        private DateTime? _Updatetime = DateTime.Now;
		//[Required(ErrorMessage = "updatetime是必须")]
		public DateTime? Updatetime
        private string? _Title ="";
		[Required(ErrorMessage = "标题是必须")]
		public string? Title
        private int? _State =0;
		//[Required(ErrorMessage = "state是必须")]
		public int? State
        private DateTime? _Checktime =DateTime.Now;
		//[Required(ErrorMessage = "checktime是必须")]
		public DateTime? Checktime
        private string? _Seed ="";
		[Required(ErrorMessage = "唯一标识是必须")]
		public string? Seed
        private int? _Violation_cnt =0;
		//[Required(ErrorMessage = "violation_cnt是必须")]
		public int? Violation_cnt
        private int? _Click_pv =0;
		///[Required(ErrorMessage = "click_pv是必须")]
		public int? Click_pv
        private int? _Save_pv =0;
		//[Required(ErrorMessage = "save_pv是必须")]
		public int? Save_pv
        private int? _Expired_days =0;
		//[Required(ErrorMessage = "expired_days是必须")]
		public int? Expired_days
        private DateTime? _Expired_at = DateTime.Now;
		//[Required(ErrorMessage = "expired_at是必须")]
		public DateTime? Expired_at
        private int? _Last_click_pv =0;
		//[Required(ErrorMessage = "last_click_pv是必须")]
		public int? Last_click_pv
        private int? _Last_save_pv =0;
		//[Required(ErrorMessage = "last_save_pv是必须")]
		public int? Last_save_pv
        
 
		#endregion
 

	}
}