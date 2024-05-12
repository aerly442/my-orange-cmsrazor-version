
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    
	public class News_markDTO
	{
 
		#region 属性
		
		
		private int _Id = 0;
		/// <summary>
		///序号
		/// </summary>
		[Display(Name = "编号")]
		public int Id
        {
			set { this._Id = value; }
		}


		private DateTime _Createtime = DateTime.Now;
		/// <summary>
		///创建时间
		/// </summary>
		[Display(Name = "创建时间")]
		public DateTime Createtime
        {
			set { this._Createtime = value; }
		}
		
		
	        private string? _Code ="";
		[Required(ErrorMessage = "代码是必须")]
		public string? Code
        private string? _Content ="";
		[Required(ErrorMessage = "内容是必须")]
		public string? Content
        private string? _Type ="";
		[Required(ErrorMessage = "类型是必须")]
		public string? Type
        private DateTime? _Updatetime =DateTime.Now;
		//[Required(ErrorMessage = "updatetime是必须")]
		public DateTime? Updatetime
        private string? _Title ="";
		[Required(ErrorMessage = "标题是必须")]
		public string? Title
        
 
		#endregion
 

	}
}