
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    {		
	public class News_resource	{
 
		#region 属性
		
		
		private int _Id = 0;
		/// <summary>
		///序号
		/// </summary>
		public int Id
        {			get { return this._Id; }
			set { this._Id = value; }
		}


		private DateTime _Createtime = DateTime.Now;
		/// <summary>
		///创建时间
		/// </summary>
		public DateTime Createtime
        {			get { return this._Createtime; }
			set { this._Createtime = value; }
		}
		
		
	        private string? _Resource ="";  
		public string? Resource		{			get { return this._Resource; }			set { this._Resource = value; }		} 
        private string? _Note ="";  
		public string? Note		{			get { return this._Note; }			set { this._Note = value; }		} 
        private DateTime? _Updatetime =DateTime.Now;  
		public DateTime? Updatetime		{			get { return this._Updatetime; }			set { this._Updatetime = value; }		} 
        private string? _Title ="";  
		public string? Title		{			get { return this._Title; }			set { this._Title = value; }		} 
        private int? _State =0;  
		public int? State		{			get { return this._State; }			set { this._State = value; }		} 
        private DateTime? _Checktime =DateTime.Now;  
		public DateTime? Checktime		{			get { return this._Checktime; }			set { this._Checktime = value; }		} 
        private string? _Seed ="";  
		public string? Seed		{			get { return this._Seed; }			set { this._Seed = value; }		} 
        private int? _Violation_cnt =0;  
		public int? Violation_cnt		{			get { return this._Violation_cnt; }			set { this._Violation_cnt = value; }		} 
        private int? _Click_pv =0;  
		public int? Click_pv		{			get { return this._Click_pv; }			set { this._Click_pv = value; }		} 
        private int? _Save_pv =0;  
		public int? Save_pv		{			get { return this._Save_pv; }			set { this._Save_pv = value; }		} 
        private int? _Expired_days =0;  
		public int? Expired_days		{			get { return this._Expired_days; }			set { this._Expired_days = value; }		} 
        private DateTime? _Expired_at = DateTime.Now;  
		public DateTime? Expired_at		{			get { return this._Expired_at; }			set { this._Expired_at = value; }		} 
        private int? _Last_click_pv =0;  
		public int? Last_click_pv		{			get { return this._Last_click_pv; }			set { this._Last_click_pv = value; }		} 
        private int? _Last_save_pv =0;  
		public int? Last_save_pv		{			get { return this._Last_save_pv; }			set { this._Last_save_pv = value; }		} 
        
 
		#endregion
 

	}
}