
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    
{
		
	public class Film_dataDTO
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
		
		
	    private string? _Title ="";
	    [Display(Name = "名称")]
		[Required(ErrorMessage = "名称是必须")]
		public string? Title
		{
			get { return this._Title; }
			set { this._Title = value; }
		}
 
        private string? _Content ="";
	    [Display(Name = "内容")]
		[Required(ErrorMessage = "内容是必须")]
		public string? Content
		{
			get { return this._Content; }
			set { this._Content = value; }
		}
 
        private string? _Bt_file_url ="";
	    [Display(Name = "BT种子地址")]
		[Required(ErrorMessage = "BT种子地址是必须")]
		public string? Bt_file_url
		{
			get { return this._Bt_file_url; }
			set { this._Bt_file_url = value; }
		}
 
        
 
		#endregion
 

	}
}
