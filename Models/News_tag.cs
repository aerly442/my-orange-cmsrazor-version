
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    
{
		
	public class News_tag	{
 
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
		
		
	        private string? _Tag ="";
  
		public string? Tag
		{
			get { return this._Tag; }
			set { this._Tag = value; }
		}
 
        private int? _NewsId =0;
  
		public int? NewsId
		{
			get { return this._NewsId; }
			set { this._NewsId = value; }
		}
 
        // public News? news{get;set;}
 
		#endregion
 

	}
}
