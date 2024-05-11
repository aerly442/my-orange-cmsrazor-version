
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    {		
	public class News_resource_listDTO
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
		
		
	        private int? _Newsid =0;	    [Display(Name = "文章编号")]
		[Required(ErrorMessage = "文章编号是必须")]
		public int? Newsid		{			get { return this._Newsid; }			set { this._Newsid = value; }		} 
        private int? _Newsresourceid =0;	    [Display(Name = "资源编号")]
		[Required(ErrorMessage = "资源编号是必须")]
		public int? Newsresourceid		{			get { return this._Newsresourceid; }			set { this._Newsresourceid = value; }		} 
        private DateTime? _Updatetime =DateTime.Now;	    [Display(Name = "更新时间")]
		[Required(ErrorMessage = "更新时间是必须")]
		public DateTime? Updatetime		{			get { return this._Updatetime; }			set { this._Updatetime = value; }		}

        [Display(Name = "文章标题")]
        public string? Title { get; set; }

        [Display(Name = "资源名称")]
        public string? Name { get; set; }

 

        #endregion


    }
}