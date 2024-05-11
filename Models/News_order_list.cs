
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    
{
		
	public class News_order_list	{
 
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
		
		private int? _Userid =0;
  
		public int? Userid
		{
			get { return this._Userid; }
			set { this._Userid = value; }
		}
		
	    private int? _Newsid =0;
  
		public int? Newsid
		{
			get { return this._Newsid; }
			set { this._Newsid = value; }
		}
 
        private string? _Email ="";
  
		public string? Email
		{
			get { return this._Email; }
			set { this._Email = value; }
		}
 
        private string? _User_code ="";
  
		public string? User_code
		{
			get { return this._User_code; }
			set { this._User_code = value; }
		}
 
        private string? _Note ="";
  
		public string? Note
		{
			get { return this._Note; }
			set { this._Note = value; }
		}
 
        private DateTime? _Updatetime =DateTime.Now;
  
		public DateTime? Updatetime
		{
			get { return this._Updatetime; }
			set { this._Updatetime = value; }
		}
 
        private int? _Pay_state =0;
  
		public int? Pay_state
		{
			get { return this._Pay_state; }
			set { this._Pay_state = value; }
		}
 
        private int? _Pay_price =0;
  
		public int? Pay_price
		{
			get { return this._Pay_price; }
			set { this._Pay_price = value; }
		}
 
        private DateTime? _Pay_time =DateTime.Now;
  
		public DateTime? Pay_time
		{
			get { return this._Pay_time; }
			set { this._Pay_time = value; }
		}
 
        private string? _Trade_no ="";
  
		public string? Trade_no
		{
			get { return this._Trade_no; }
			set { this._Trade_no = value; }
		}
 
        private string? _OrderId ="";
  
		public string? OrderId
		{
			get { return this._OrderId; }
			set { this._OrderId = value; }
		}
 
        private string? _PayUrl ="";
  
		public string? PayUrl
		{
			get { return this._PayUrl; }
			set { this._PayUrl = value; }
		}
 
        
 
		#endregion
 

	}
}
