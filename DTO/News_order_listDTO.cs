
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    
{
		
	public class News_order_listDTO
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
		

		private int? _Userid =0;
		[Display(Name = "用户ID")]
		[Required(ErrorMessage = "用户ID是必须")]
		public int? Userid
		{
			get { return this._Userid; }
			set { this._Userid = value; }
		}
		
	    private int? _Newsid =0;
	    [Display(Name = "文章ID")]
		[Required(ErrorMessage = "文章ID是必须")]
		public int? Newsid
		{
			get { return this._Newsid; }
			set { this._Newsid = value; }
		}
 
        private string? _Email ="";
	    [Display(Name = "Email")]
		//[Required(ErrorMessage = "email是必须")]
		public string? Email
		{
			get { return this._Email; }
			set { this._Email = value; }
		}
 
        private string? _User_code ="";
	    [Display(Name = "用户编码")]
		[Required(ErrorMessage = "用户编码是必须")]
		public string? User_code
		{
			get { return this._User_code; }
			set { this._User_code = value; }
		}
 
        private string? _Note ="";
	    [Display(Name = "备注")]
		//[Required(ErrorMessage = "note是必须")]
		public string? Note
		{
			get { return this._Note; }
			set { this._Note = value; }
		}
 
        private DateTime? _Updatetime =DateTime.Now;
	    [Display(Name = "更新时间")]
		[Required(ErrorMessage = "更新时间是必须")]
		public DateTime? Updatetime
		{
			get { return this._Updatetime; }
			set { this._Updatetime = value; }
		}
 
        private int? _Pay_state =0;
	    [Display(Name = "支付状态")]
		[Required(ErrorMessage = "支付状态是必须")]
		public int? Pay_state
		{
			get { return this._Pay_state; }
			set { this._Pay_state = value; }
		}
 
        private int? _Pay_price =0;
	    [Display(Name = "支付价格")]
		//[Required(ErrorMessage = "支付价格是必须")]
		public int? Pay_price
		{
			get { return this._Pay_price; }
			set { this._Pay_price = value; }
		}
 
        private DateTime? _Pay_time =DateTime.Now;
	    [Display(Name = "支付时间")]
		//[Required(ErrorMessage = "支付时间是必须")]
		public DateTime? Pay_time
		{
			get { return this._Pay_time; }
			set { this._Pay_time = value; }
		}
 
        private string? _Trade_no ="";
	    [Display(Name = "订单号")]
		[Required(ErrorMessage = "订单号是必须")]
		public string? Trade_no
		{
			get { return this._Trade_no; }
			set { this._Trade_no = value; }
		}
 
        private string? _OrderId ="";
	    [Display(Name = "订单ID")]
		[Required(ErrorMessage = "订单ID是必须")]
		public string? OrderId
		{
			get { return this._OrderId; }
			set { this._OrderId = value; }
		}
 
        private string? _PayUrl ="";
	    [Display(Name = "支付URL")]
		//[Required(ErrorMessage = "支付URL是必须")]
		public string? PayUrl
		{
			get { return this._PayUrl; }
			set { this._PayUrl = value; }
		}
 
		[Display(Name = "标题")]
        public string? Title {get;set;}

		[Display(Name = "称呼")]
        public string? Nickname {get;set;}
        
 
		#endregion
 

	}
}
