
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    {		
	public class News_markDTO
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
		
		
	        private string? _Code ="";	    [Display(Name = "代码")]
		[Required(ErrorMessage = "代码是必须")]
		public string? Code		{			get { return this._Code; }			set { this._Code = value; }		} 
        private string? _Content ="";	    [Display(Name = "内容")]
		[Required(ErrorMessage = "内容是必须")]
		public string? Content		{			get { return this._Content; }			set { this._Content = value; }		} 
        private string? _Type ="";	    [Display(Name = "类型")]
		[Required(ErrorMessage = "类型是必须")]
		public string? Type		{			get { return this._Type; }			set { this._Type = value; }		} 
        private DateTime? _Updatetime =DateTime.Now;	    [Display(Name = "更新时间")]
		//[Required(ErrorMessage = "updatetime是必须")]
		public DateTime? Updatetime		{			get { return this._Updatetime; }			set { this._Updatetime = value; }		} 
        private string? _Title ="";	    [Display(Name = "标题")]
		[Required(ErrorMessage = "标题是必须")]
		public string? Title		{			get { return this._Title; }			set { this._Title = value; }		} 
        
 
		#endregion
 

	}
}