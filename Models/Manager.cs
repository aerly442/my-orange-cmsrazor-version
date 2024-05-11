using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace MyOrangeCMS_RazorVersion.Models
{
    public class Manager
    {
        #region 属性


        /// <summary>
        ///序号
        /// </summary>
        /// 
        // [Column]
       
        public int Id { get; set; } = 0;





        private string _username = "";
 
        public string username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        private string _password = "";
   
        public string password
        {
            get { return this._password; }
            set { this._password = value; }
        }


        /// <summary>
        /// 获取MD5后的密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetEncodePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                password = "123456";
            }

            int  passwordLength = 16; //MD5后默认长度

            string newPassword = string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
            string result      = string.IsNullOrEmpty(newPassword) == false && newPassword.Length > passwordLength ? newPassword.Substring(0, passwordLength) : newPassword;
            return result;

        }

        private string _name = "";
 
        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private string _tel = "";
 
        public string tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        private string _depart = "";
 
        public string depart
        {
            get { return this._depart; }
            set { this._depart = value; }
        }

        private int _power = 0;
 
        public int power
        {
            get { return this._power; }
            set { this._power = value; }
        }

        private DateTime? _lastlogindatetime = DateTime.Now;
 
        public DateTime? lastlogindatetime
        {
            get { return this._lastlogindatetime; }
            set { this._lastlogindatetime = value; }
        }

        private string? _lastloginip = "";
 
        public string? lastloginip
        {
            get { return this._lastloginip; }
            set { this._lastloginip = value; }
        }

        private DateTime _createtime = DateTime.Now;
        /// <summary>
        ///创建时间
        /// </summary>
        /// 
 
        public DateTime createtime
        {
            get { return this._createtime; }
            set { this._createtime = value; }
        }



        #endregion
    }
}
