using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
{
    public class User   {
       public User(){
       }

        
        
        private int _Id = 0;
        public int Id
        {
        get { return this._Id; }
        set { this._Id = value; }
        }
        private string? _Username ;
        public string? Username
        {
        get { return this._Username; }
        set { this._Username = value; }
        }
        private string? _Email = "";
        public string? Email
        {
        get { return this._Email; }
        set { this._Email = value; }
        }
        private string? _Mobile ;
        public string? Mobile
        {
        get { return this._Mobile; }
        set { this._Mobile = value; }
        }
        private string? _Password = "";
        public string? Password
        {
        get { return this._Password; }
        set { this._Password = value; }
        }
        private string? _Nickname = "";
        public string? Nickname
        {
        get { return this._Nickname; }
        set { this._Nickname = value; }
        }
        private string? _Headerpic = "";
        public string? Headerpic
        {
        get { return this._Headerpic; }
        set { this._Headerpic = value; }
        }
        private string? _Sex = "";
        public string? Sex
        {
        get { return this._Sex; }
        set { this._Sex = value; }
        }
        private string? _Birthday = "";
        public string? Birthday
        {
        get { return this._Birthday; }
        set { this._Birthday = value; }
        }
        private int _Age = 0;
        public int Age
        {
        get { return this._Age; }
        set { this._Age = value; }
        }
        private string? _Openid ;
        public string? Openid
        {
        get { return this._Openid; }
        set { this._Openid = value; }
        }
        private string? _Sns = "";
        public string? Sns
        {
        get { return this._Sns; }
        set { this._Sns = value; }
        }
        private int _Snstype = 0;
        public int Snstype
        {
        get { return this._Snstype; }
        set { this._Snstype = value; }
        }
        private string? _Continent = "";
        public string? Continent
        {
        get { return this._Continent; }
        set { this._Continent = value; }
        }
        private string? _Country = "";
        public string? Country
        {
        get { return this._Country; }
        set { this._Country = value; }
        }
        private string? _City = "";
        public string? City
        {
        get { return this._City; }
        set { this._City = value; }
        }
        private string? _Intro = "";
        public string? Intro
        {
        get { return this._Intro; }
        set { this._Intro = value; }
        }
        private int _Active = 0;
        public int Active
        {
        get { return this._Active; }
        set { this._Active = value; }
        }
        private DateTime _Activetime = DateTime.Now;
        public DateTime Activetime
        {
        get { return this._Activetime; }
        set { this._Activetime = value; }
        }
        private int _Ismaster = 0;
        public int Ismaster
        {
        get { return this._Ismaster; }
        set { this._Ismaster = value; }
        }
        private int _Isauthorized = 0;
        public int Isauthorized
        {
        get { return this._Isauthorized; }
        set { this._Isauthorized = value; }
        }
        private int _State = 0;
        public int State
        {
        get { return this._State; }
        set { this._State = value; }
        }
        private double ? _Totalmoney = 0;
        public double? Totalmoney
        {
        get { return this._Totalmoney; }
        set { this._Totalmoney = value; }
        }
        private DateTime _Lastlogindatetime = DateTime.Now;
        public DateTime Lastlogindatetime
        {
        get { return this._Lastlogindatetime; }
        set { this._Lastlogindatetime = value; }
        }
        private int _Logincount = 0;
        public int Logincount
        {
        get { return this._Logincount; }
        set { this._Logincount = value; }
        }
        private DateTime _Createtime = DateTime.Now;
        public DateTime Createtime
        {
        get { return this._Createtime; }
        set { this._Createtime = value; }
        }
        private int _Totalscore = 0;
        public int Totalscore
        {
        get { return this._Totalscore; }
        set { this._Totalscore = value; }
        }
        private double ? _Master_score = 0;
        public double? Master_score
        {
        get { return this._Master_score; }
        set { this._Master_score = value; }
        }
        private int _Funs_count = 0;
        public int Funs_count
        {
        get { return this._Funs_count; }
        set { this._Funs_count = value; }
        }
        private int _Friends_count = 0;
        public int Friends_count
        {
        get { return this._Friends_count; }
        set { this._Friends_count = value; }
        }
        private int _Careusers_count = 0;
        public int Careusers_count
        {
        get { return this._Careusers_count; }
        set { this._Careusers_count = value; }
        }
        private string? _Homeplace = "";
        public string? Homeplace
        {
        get { return this._Homeplace; }
        set { this._Homeplace = value; }
        }
        private string? _Job = "";
        public string? Job
        {
        get { return this._Job; }
        set { this._Job = value; }
        }
        private string? _School = "";
        public string? School
        {
        get { return this._School; }
        set { this._School = value; }
        }
        private string? _Language = "";
        public string? Language
        {
        get { return this._Language; }
        set { this._Language = value; }
        }
        private string? _Tripplace = "";
        public string? Tripplace
        {
        get { return this._Tripplace; }
        set { this._Tripplace = value; }
        }
        private string? _Interest = "";
        public string? Interest
        {
        get { return this._Interest; }
        set { this._Interest = value; }
        }
        private string? _Aim = "";
        public string? Aim
        {
        get { return this._Aim; }
        set { this._Aim = value; }
        }
        private DateTime _Updatetime = DateTime.Now;
        public DateTime Updatetime
        {
        get { return this._Updatetime; }
        set { this._Updatetime = value; }
        }
        private int _Usertype = 0;
        public int Usertype
        {
        get { return this._Usertype; }
        set { this._Usertype = value; }
        }
        private string? _Name = "";
        public string? Name
        {
        get { return this._Name; }
        set { this._Name = value; }
        }
        private int _Recommend_userid = 0;
        public int Recommend_userid
        {
        get { return this._Recommend_userid; }
        set { this._Recommend_userid = value; }
        }
        private string? _Recommend_code = "";
        public string? Recommend_code
        {
        get { return this._Recommend_code; }
        set { this._Recommend_code = value; }
        }
        private int _Login_type = 0;
        public int Login_type
        {
        get { return this._Login_type; }
        set { this._Login_type = value; }
        }
        private int _Adjust_type = 0;
        public int Adjust_type
        {
        get { return this._Adjust_type; }
        set { this._Adjust_type = value; }
        }

   }
}
