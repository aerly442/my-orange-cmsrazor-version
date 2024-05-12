
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    
{
		
	public class News_categories	{
 
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
		
		
	        private string _Name ="";
  
		public string Name
		{
			get { return this._Name; }
			set { this._Name = value; }
		}
 
        private string _Code ="";
  
		public string Code
		{
			get { return this._Code; }
			set { this._Code = value; }
		}
 
        private int _Sort =0;
  
		public int Sort
		{
			get { return this._Sort; }
			set { this._Sort = value; }
		}
 
        //public News? news {get;set;}
 
		#endregion
 

	}
}
