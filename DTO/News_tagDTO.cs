
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    
{
		
	public class News_tagDTO
	{
 
		#region 属性
		
		
		private int _Id = 0;
		/// <summary>
		///序号
		/// </summary>
		[Display(Name = "编号")]
		public int Id
        {
			get { return this._Id; }
			set { this._Id = value; }
		}


		private DateTime _Createtime = DateTime.Now;
		/// <summary>
		///创建时间
		/// </summary>
		[Display(Name = "创建时间")]
		public DateTime Createtime
        {
			get { return this._Createtime; }
			set { this._Createtime = value; }
		}
		
		
	    private string? _Tag ="";
	    [Display(Name = "Tag")]
		[Required(ErrorMessage = "Tag名称是必须")]
		public string? Tag
		{
			get { return this._Tag; }
			set { this._Tag = value; }
		}
 
        private int? _NewsId =0;
	    [Display(Name = "文章ID")]
		[Required(ErrorMessage = "文章ID是必须")]
		public int? NewsId
		{
			get { return this._NewsId; }
			set { this._NewsId = value; }
		}
 
        [Display(Name = "文章标题")]
        public string? Title {get;set;}

		#endregion
 

	}
}
