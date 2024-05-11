
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    {		
	public class News_resourceDTO
	{
 
		#region 属性
		
		
		private int _Id = 0;
        /// <summary>
        ///序号
        /// </summary>
        [Display(Name = "编号")]
        public int Id
        {			get { return this._Id; }
			set { this._Id = value; }
		}


		private DateTime _Createtime = DateTime.Now;
        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime Createtime
        {			get { return this._Createtime; }
			set { this._Createtime = value; }
		}
		
		
	    private string? _Resource ="";	    [Display(Name = "内容")]
		[Required(ErrorMessage = "内容是必须")]
		public string? Resource		{			get { return this._Resource; }			set { this._Resource = value; }		} 
        private string? _Note ="";	    [Display(Name = "备注")]
		//[Required(ErrorMessage = "备注是必须")]
		public string? Note		{			get { return this._Note; }			set { this._Note = value; }		} 
        private DateTime? _Updatetime = DateTime.Now;	    [Display(Name = "更新时间")]
		//[Required(ErrorMessage = "updatetime是必须")]
		public DateTime? Updatetime		{			get { return this._Updatetime; }			set { this._Updatetime = value; }		} 
        private string? _Title ="";	    [Display(Name = "标题")]
		[Required(ErrorMessage = "标题是必须")]
		public string? Title		{			get { return this._Title; }			set { this._Title = value; }		} 
        private int? _State =0;	    [Display(Name = "状态")]
		//[Required(ErrorMessage = "state是必须")]
		public int? State		{			get { return this._State; }			set { this._State = value; }		} 
        private DateTime? _Checktime =DateTime.Now;	    [Display(Name = "检查时间")]
		//[Required(ErrorMessage = "checktime是必须")]
		public DateTime? Checktime		{			get { return this._Checktime; }			set { this._Checktime = value; }		} 
        private string? _Seed ="";	    [Display(Name = "唯一标识")]
		[Required(ErrorMessage = "唯一标识是必须")]
		public string? Seed		{			get { return this._Seed; }			set { this._Seed = value; }		} 
        private int? _Violation_cnt =0;	    [Display(Name = "违规")]
		//[Required(ErrorMessage = "violation_cnt是必须")]
		public int? Violation_cnt		{			get { return this._Violation_cnt; }			set { this._Violation_cnt = value; }		} 
        private int? _Click_pv =0;	    [Display(Name = "点击")]
		///[Required(ErrorMessage = "click_pv是必须")]
		public int? Click_pv		{			get { return this._Click_pv; }			set { this._Click_pv = value; }		} 
        private int? _Save_pv =0;	    [Display(Name = "保存")]
		//[Required(ErrorMessage = "save_pv是必须")]
		public int? Save_pv		{			get { return this._Save_pv; }			set { this._Save_pv = value; }		} 
        private int? _Expired_days =0;	    [Display(Name = "过期天数")]
		//[Required(ErrorMessage = "expired_days是必须")]
		public int? Expired_days		{			get { return this._Expired_days; }			set { this._Expired_days = value; }		} 
        private DateTime? _Expired_at = DateTime.Now;	    [Display(Name = "过期时间")]
		//[Required(ErrorMessage = "expired_at是必须")]
		public DateTime? Expired_at		{			get { return this._Expired_at; }			set { this._Expired_at = value; }		} 
        private int? _Last_click_pv =0;	    [Display(Name = "上次点击")]
		//[Required(ErrorMessage = "last_click_pv是必须")]
		public int? Last_click_pv		{			get { return this._Last_click_pv; }			set { this._Last_click_pv = value; }		} 
        private int? _Last_save_pv =0;	    [Display(Name = "上次保存")]
		//[Required(ErrorMessage = "last_save_pv是必须")]
		public int? Last_save_pv		{			get { return this._Last_save_pv; }			set { this._Last_save_pv = value; }		} 
        
 
		#endregion
 

	}
}