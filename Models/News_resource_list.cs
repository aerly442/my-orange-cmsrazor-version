
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    
{
		
	public class News_resource_list	{
 
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
		
		
	    private int? _Newsid =0;
  
		public int? Newsid
		{
			get { return this._Newsid; }
			set { this._Newsid = value; }
		}
 
        private int? _Newsresourceid =0;
  
		public int? Newsresourceid
		{
			get { return this._Newsresourceid; }
			set { this._Newsresourceid = value; }
		}
 
        private DateTime? _Updatetime =DateTime.Now;
  
		public DateTime? Updatetime
		{
			get { return this._Updatetime; }
			set { this._Updatetime = value; }
		}
 
        
 
		#endregion
 

	}
}
