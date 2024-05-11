using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MyOrangeCMS_RazorVersion.Models
{
    public class User_authorize_code   {
       
      #region  属性定义
      private int _Id = 0;
      public int Id
      {
      get { return this._Id; }
      set { this._Id = value; }
      }
      private string? _Nickname = "";
      public string? Nickname
      {
      get { return this._Nickname; }
      set { this._Nickname = value; }
      }
      private string? _Openid = "";
      public string? Openid
      {
      get { return this._Openid; }
      set { this._Openid = value; }
      }
      private string? _Mobile = "";
      public string? Mobile
      {
      get { return this._Mobile; }
      set { this._Mobile = value; }
      }
      private string? _Email = "";
      public string? Email
      {
      get { return this._Email; }
      set { this._Email = value; }
      }
      private string? _Code = "";
      public string? Code
      {
      get { return this._Code; }
      set { this._Code = value; }
      }
      private DateTime _Sendtime = DateTime.Now;
      public DateTime Sendtime
      {
      get { return this._Sendtime; }
      set { this._Sendtime = value; }
      }
      private int _Sendstate = 0;
      public int Sendstate
      {
      get { return this._Sendstate; }
      set { this._Sendstate = value; }
      }
      private int _State = 0;
      public int State
      {
      get { return this._State; }
      set { this._State = value; }
      }
      private DateTime _Createtime = DateTime.Now;
      public DateTime Createtime
      {
      get { return this._Createtime; }
      set { this._Createtime = value; }
      }
      private string? _Messagetype = "";
      public string? Messagetype
      {
      get { return this._Messagetype; }
      set { this._Messagetype = value; }
      }
      #endregion

   }
}
