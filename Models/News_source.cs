
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    
	public class News_source	{
 
		#region 属性
		
		
		private int _Id = 0;
		/// <summary>
		///序号
		/// </summary>
		public int Id
        {
			set { this._Id = value; }
		}


		private DateTime _Createtime = DateTime.Now;
		/// <summary>
		///创建时间
		/// </summary>
		public DateTime Createtime
        {
			set { this._Createtime = value; }
		}
		
		
	        private string? _Title ="";
		public string? Title
        private string? _Note ="";
		public string? Note
        private string? _Url ="";
		public string? Url
        private string? _Type ="";
		public string? Type
        private DateTime? _Updatetime =DateTime.Now;
		public DateTime? Updatetime
        
 
		#endregion
 

	}
}