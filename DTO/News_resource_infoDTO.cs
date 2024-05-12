
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO
    
{
		
	public class News_resource_infoDTO
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

        [Display(Name = "标题")]
        public string? Title { get; set; }


        #endregion


    }
}
