
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    
{
	//[Table("news")]	
	public class News	{
 
		#region 属性
		
		
		private int _Id = 0;
		/// <summary>
		///序号
		/// </summary>
		public int Id
        {
			get { return this._Id; }
			set { this._Id = value; }
		}


		private DateTime _Createtime = DateTime.Now;
		/// <summary>
		///创建时间
		/// </summary>
		public DateTime Createtime
        {
			get { return this._Createtime; }
			set { this._Createtime = value; }
		}
		
		
	        private string? _Title ="";
  
		public string? Title
		{
			get { return this._Title; }
			set { this._Title = value; }
		}
 
        private string? _Content ="";
  
		public string? Content
		{
			get { return this._Content; }
			set { this._Content = value; }
		}
 
        private string? _Author ="";
  
		public string? Author
		{
			get { return this._Author; }
			set { this._Author = value; }
		}
 
        private string? _Source ="";
  
		public string? Source
		{
			get { return this._Source; }
			set { this._Source = value; }
		}
 
        private string? _News_categories_code ="";
  
		public string? News_categories_code
		{
			get { return this._News_categories_code; }
			set { this._News_categories_code = value; }
		}
 
        private string? _Mainpic ="";
  
		public string? Mainpic
		{
			get { return this._Mainpic; }
			set { this._Mainpic = value; }
		}
 
        private string? _File ="";
  
		public string? File
		{
			get { return this._File; }
			set { this._File = value; }
		}
 
        private string? _Url ="";
  
		public string? Url
		{
			get { return this._Url; }
			set { this._Url = value; }
		}
 
        private int? _Sort =0;
  
		public int? Sort
		{
			get { return this._Sort; }
			set { this._Sort = value; }
		}
 
        private int? _State =0;
  
		public int? State
		{
			get { return this._State; }
			set { this._State = value; }
		}
 
        private int? _Hot =0;
  
		public int? Hot
		{
			get { return this._Hot; }
			set { this._Hot = value; }
		}
 
        private string? _Key_word ="";
  
		public string? Key_word
		{
			get { return this._Key_word; }
			set { this._Key_word = value; }
		}
 
        private string? _Abstract ="";
  
		public string? Abstract
		{
			get { return this._Abstract; }
			set { this._Abstract = value; }
		}
 
        private int? _Visit =0;
  
		public int? Visit
		{
			get { return this._Visit; }
			set { this._Visit = value; }
		}
 
        private int? _Is_charge =0;
  
		public int? Is_charge
		{
			get { return this._Is_charge; }
			set { this._Is_charge = value; }
		}
 
        private DateTime? _Charge_starttime =DateTime.Now;
  
		public DateTime? Charge_starttime
		{
			get { return this._Charge_starttime; }
			set { this._Charge_starttime = value; }
		}
 
        private DateTime? _Charge_endtime =DateTime.Now;
  
		public DateTime? Charge_endtime
		{
			get { return this._Charge_endtime; }
			set { this._Charge_endtime = value; }
		}
 
        private int? _Price =0;
  
		public int? Price
		{
			get { return this._Price; }
			set { this._Price = value; }
		}

        //是否允许评论
		private int? _Is_comment = 0;
  
		public int? Is_comment
		{
			get { return this._Is_comment; }
			set { this._Is_comment = value; }
		}


		//收费方式0 内容收费 1 链接收费
		private int? _Charge_type = 0;
  
		public int? Charge_type
		{
			get { return this._Charge_type; }
			set { this._Charge_type = value; }
		}
 
		#endregion
 

	}
}
