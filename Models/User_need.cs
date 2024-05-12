
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    
	public class User_need	{
 
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
		
		
	        private DateTime? _Updatetime =DateTime.Now;
		public DateTime? Updatetime
        private string? _Title ="";
		public string? Title
        private string? _Note ="";
		public string? Note
        private string? _Email ="";
		public string? Email
        private int? _State =0;
		public int? State
        private int? _Pay_type =0;
		public int? Pay_type
        
 
		#endregion
 

	}
}