
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    {		
	public class News_categoriesDTO
	{
 
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
		
		
	        private string _Name ="";	    [Display(Name = "栏目名称")]
		[Required(ErrorMessage = "栏目名称是必须")]
		public string Name		{			get { return this._Name; }			set { this._Name = value; }		} 
        private string _Code ="";	    [Display(Name = "栏目代码")]
		[Required(ErrorMessage = "栏目代码是必须")]
		public string Code		{			get { return this._Code; }			set { this._Code = value; }		} 
        private int _Sort =0;	    [Display(Name = "排序")]
		[Required(ErrorMessage = "排序是必须")]
		public int Sort		{			get { return this._Sort; }			set { this._Sort = value; }		} 
        
 
		#endregion
 

	}
}