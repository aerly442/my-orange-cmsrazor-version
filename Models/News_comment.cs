using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
{
    public class News_comment   {
       public News_comment(){
       }

        
        
        private int _Id = 0;
        public int Id
        {
        get { return this._Id; }
        set { this._Id = value; }
        }
        private string _Nickname = "";
        public string Nickname
        {
        get { return this._Nickname; }
        set { this._Nickname = value; }
        }
        private string _Content = "";
        public string Content
        {
        get { return this._Content; }
        set { this._Content = value; }
        }
        private DateTime _Createtime = DateTime.Now;
        public DateTime Createtime
        {
        get { return this._Createtime; }
        set { this._Createtime = value; }
        }
        private DateTime _Updatetime = DateTime.Now;
        public DateTime Updatetime
        {
        get { return this._Updatetime; }
        set { this._Updatetime = value; }
        }
        private int _State = 0;
        public int State
        {
        get { return this._State; }
        set { this._State = value; }
        }
        private int _Parentid = 0;
        public int Parentid
        {
        get { return this._Parentid; }
        set { this._Parentid = value; }
        }
        private int _Userid = 0;
        public int Userid
        {
        get { return this._Userid; }
        set { this._Userid = value; }
        }
        private int _Likecount = 0;
        public int Likecount
        {
        get { return this._Likecount; }
        set { this._Likecount = value; }
        }
        private int _Hatecount = 0;
        public int Hatecount
        {
        get { return this._Hatecount; }
        set { this._Hatecount = value; }
        }

        public int Newsid{get;set;} 

        public string Title{get;set;} 

   }
}
