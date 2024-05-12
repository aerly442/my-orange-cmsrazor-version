using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.DTO
{
    public class News_commentDTO   {
       public News_commentDTO(){
       }
 
        
        private int _Id = 0;
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Id是必须")]
        public int Id
        {
        get { return this._Id; }
        set { this._Id = value; }
        }
        private string _Nickname = "";
        [Display(Name = "称呼")]
        [Required(ErrorMessage = "称呼是必须")]
        public string Nickname
        {
        get { return this._Nickname; }
        set { this._Nickname = value; }
        }
        private string _Content = "";
        [Display(Name = "内容")]
        [Required(ErrorMessage = "内容是必须")]
        public string Content
        {
        get { return this._Content; }
        set { this._Content = value; }
        }
        private DateTime _Createtime = DateTime.Now;
        [Display(Name = "创建时间")]
        public DateTime Createtime
        {
        get { return this._Createtime; }
        set { this._Createtime = value; }
        }
        private DateTime _Updatetime = DateTime.Now;
        [Display(Name = "保存时间")]
        public DateTime Updatetime
        {
        get { return this._Updatetime; }
        set { this._Updatetime = value; }
        }
        private int _State = 0;
        [Display(Name = "状态")]
        public int State
        {
        get { return this._State; }
        set { this._State = value; }
        }
        private int _Parentid = 0;
        [Display(Name = "父ID")]
        public int Parentid
        {
        get { return this._Parentid; }
        set { this._Parentid = value; }
        }
        private int _Userid = 0;
        [Display(Name = "用户ID")]
        public int Userid
        {
        get { return this._Userid; }
        set { this._Userid = value; }
        }
        private int _Likecount = 0;
        [Display(Name = "点赞数")]
        public int Likecount
        {
        get { return this._Likecount; }
        set { this._Likecount = value; }
        }
        private int _Hatecount = 0;
        [Display(Name = "踩数量")]
        public int Hatecount
        {
        get { return this._Hatecount; }
        set { this._Hatecount = value; }
        }
        
        [Display(Name = "标题")]
        public string? Title {get;set;}

        [Display(Name = "标题Id")]
        public int? Newsid{get;set;} 

       
   }
}
