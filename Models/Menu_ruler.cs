
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    {		
	public class Menu_ruler	{
 
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
		
		
	        private string? _Username ="";  
		public string? Username		{			get { return this._Username; }			set { this._Username = value; }		} 
        private string? _Menuid ="";  
		public string? Menuid		{			get { return this._Menuid; }			set { this._Menuid = value; }		} 
        private int? _Managerid =0;  
		public int? Managerid		{			get { return this._Managerid; }			set { this._Managerid = value; }		} 
        
 
		#endregion
 

	}
}