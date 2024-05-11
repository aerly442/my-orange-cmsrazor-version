
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    {		
	public class News_sourceDTO
	{
 
		#region 属性
		
		
		private int _Id = 0;
		/// <summary>
		///序号
		/// </summary>
		[Display(Name = "编号")]
		public int Id
        {			get { return this._Id; }
			set { this._Id = value; }
		}


		private DateTime _Createtime = DateTime.Now;
		/// <summary>
		///创建时间
		/// </summary>
		[Display(Name = "创建时间")]
		public DateTime Createtime
        {			get { return this._Createtime; }
			set { this._Createtime = value; }
		}
		
		
	        private string? _Title ="";	    [Display(Name = "标题")]
		[Required(ErrorMessage = "标题是必须")]
		public string? Title		{			get { return this._Title; }			set { this._Title = value; }		} 
        private string? _Note ="";	    [Display(Name = "备注")]
		//[Required(ErrorMessage = "备注是必须")]
		public string? Note		{			get { return this._Note; }			set { this._Note = value; }		} 
        private string? _Url ="";	    [Display(Name = "Url")]
		[Required(ErrorMessage = "Url是必须")]
		public string? Url		{			get { return this._Url; }			set { this._Url = value; }		} 
        private string? _Type ="";	    [Display(Name = "类型")]
		[Required(ErrorMessage = "类型是必须")]
		public string? Type		{			get { return this._Type; }			set { this._Type = value; }		} 
        private DateTime? _Updatetime =DateTime.Now;	    [Display(Name = "更新时间")]
		[Required(ErrorMessage = "更新时间是必须")]
		public DateTime? Updatetime		{			get { return this._Updatetime; }			set { this._Updatetime = value; }		} 
        
 
		#endregion
 

	}
}