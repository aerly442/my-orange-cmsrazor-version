
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
    {		
	public class News_mark	{
 
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
		
		
	        private string? _Code ="";  
		public string? Code		{			get { return this._Code; }			set { this._Code = value; }		} 
        private string? _Content ="";  
		public string? Content		{			get { return this._Content; }			set { this._Content = value; }		} 
        private string? _Type ="";  
		public string? Type		{			get { return this._Type; }			set { this._Type = value; }		} 
        private DateTime? _Updatetime =DateTime.Now;  
		public DateTime? Updatetime		{			get { return this._Updatetime; }			set { this._Updatetime = value; }		} 
        private string? _Title ="";  
		public string? Title		{			get { return this._Title; }			set { this._Title = value; }		} 
        
 
		#endregion
 

	}
}