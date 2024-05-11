
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    
	public class Menu_ruler	{
 
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
		
		
	        private string? _Username ="";
		public string? Username
        private string? _Menuid ="";
		public string? Menuid
        private int? _Managerid =0;
		public int? Managerid
        
 
		#endregion
 

	}
}