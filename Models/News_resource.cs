
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    
	public class News_resource	{
 
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
		
		
	        private string? _Resource ="";
		public string? Resource
        private string? _Note ="";
		public string? Note
        private DateTime? _Updatetime =DateTime.Now;
		public DateTime? Updatetime
        private string? _Title ="";
		public string? Title
        private int? _State =0;
		public int? State
        private DateTime? _Checktime =DateTime.Now;
		public DateTime? Checktime
        private string? _Seed ="";
		public string? Seed
        private int? _Violation_cnt =0;
		public int? Violation_cnt
        private int? _Click_pv =0;
		public int? Click_pv
        private int? _Save_pv =0;
		public int? Save_pv
        private int? _Expired_days =0;
		public int? Expired_days
        private DateTime? _Expired_at = DateTime.Now;
		public DateTime? Expired_at
        private int? _Last_click_pv =0;
		public int? Last_click_pv
        private int? _Last_save_pv =0;
		public int? Last_save_pv
        
 
		#endregion
 

	}
}