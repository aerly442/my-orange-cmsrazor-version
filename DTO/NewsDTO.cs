
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    
{
		
	public class NewsDTO
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
		
		
	        private string? _Title ="";
	    [Display(Name = "标题")]
		[Required(ErrorMessage = "标题是必须")]
		public string? Title
		{
			get { return this._Title; }
			set { this._Title = value; }
		}
 
        private string? _Content ="";
	    [Display(Name = "内容")]
		[Required(ErrorMessage = "内容是必须")]
		public string? Content
		{
			get { return this._Content; }
			set { this._Content = value; }
		}
 
        private string? _Author ="";
	    [Display(Name = "作者")]
		//[Required(ErrorMessage = "作者是必须")]
		public string? Author
		{
			get { return this._Author; }
			set { this._Author = value; }
		}
 
        private string? _Source ="";
	    [Display(Name = "来源")]
		//[Required(ErrorMessage = "来源是必须")]
		public string? Source
		{
			get { return this._Source; }
			set { this._Source = value; }
		}
 
        private string? _News_categories_code ="";
	    [Display(Name = "栏目代码")]
		//[Required(ErrorMessage = "栏目代码是必须")]
		public string? News_categories_code
		{
			get { return this._News_categories_code; }
			set { this._News_categories_code = value; }
		}
 
        private string? _Mainpic ="";
	    [Display(Name = "主图")]
		//[Required(ErrorMessage = "主图是必须")]
		public string? Mainpic
		{
			get { return this._Mainpic; }
			set { this._Mainpic = value; }
		}
 
        private string? _File ="";
	    [Display(Name = "附件")]
		//[Required(ErrorMessage = "附件是必须")]
		public string? File
		{
			get { return this._File; }
			set { this._File = value; }
		}
 
        private string? _Url ="";
	    [Display(Name = "外链地址")]
		//[Required(ErrorMessage = "外链地址是必须")]
		public string? Url
		{
			get { return this._Url; }
			set { this._Url = value; }
		}
 
        private int? _Sort =0;
	    [Display(Name = "排序")]
		//[Required(ErrorMessage = "排序是必须")]
		public int? Sort
		{
			get { return this._Sort; }
			set { this._Sort = value; }
		}
 
        private int? _State = 0;
	    [Display(Name = "状态正常")]
		//[Required(ErrorMessage = "状态正常是必须")]
		public int? State
		{
			get { return this._State; }
			set { this._State = value; }
		}
 
        private int? _Hot =0;
	    [Display(Name = "推荐")]
		//[Required(ErrorMessage = "推荐是必须")]
		public int? Hot
		{
			get { return this._Hot; }
			set { this._Hot = value; }
		}
 
        private string? _Key_word ="";
	    [Display(Name = "关键词")]
		//[Required(ErrorMessage = "关键词是必须")]
		public string? Key_word
		{
			get { return this._Key_word; }
			set { this._Key_word = value; }
		}
 
        private string? _Abstract ="";
	    [Display(Name = "摘要")]
		//[Required(ErrorMessage = "摘要是必须")]
		public string? Abstract
		{
			get { return this._Abstract; }
			set { this._Abstract = value; }
		}
 
        private int? _Visit =0;
	    [Display(Name = "浏览量")]
		//[Required(ErrorMessage = "浏览量是必须")]
		public int? Visit
		{
			get { return this._Visit; }
			set { this._Visit = value; }
		}
 
        private int? _Is_charge =0;
	    [Display(Name = "收费")]
		//[Required(ErrorMessage = "是否收费是必须")]
		public int? Is_charge
		{
			get { return this._Is_charge; }
			set { this._Is_charge = value; }
		}
 
        private DateTime? _Charge_starttime =DateTime.Now;
	    [Display(Name = "支付开始时间")]
		//[Required(ErrorMessage = "支付开始时间是必须")]
		public DateTime? Charge_starttime
		{
			get { return this._Charge_starttime; }
			set { this._Charge_starttime = value; }
		}
 
        private DateTime? _Charge_endtime =DateTime.Now;
	    [Display(Name = "支付时间")]
		//[Required(ErrorMessage = "支付时间是必须")]
		public DateTime? Charge_endtime
		{
			get { return this._Charge_endtime; }
			set { this._Charge_endtime = value; }
		}
 
        private int? _Price =0;
	    [Display(Name = "定价")]
		//[Required(ErrorMessage = "定价是必须")]
		public int? Price
		{
			get { return this._Price; }
			set { this._Price = value; }
		}

	   [Display(Name = "栏目")]
       //类别名称
		public string? CatName {get;set;}

		[Display(Name = "评论")]
		public int? Is_comment{get;set;}
 


 		[Display(Name = "收费模式")]
		public int? Charge_type{get;set;}

 
		#endregion
 

	}
}
