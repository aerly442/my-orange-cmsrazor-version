
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


namespace MyOrangeCMS_RazorVersion.DTO

{

    public class TableDescDTO
    {

        #region 属性


        private string? _Field = "";
        
        public string? Field
        {
            get { return this._Field; }
            set { this._Field = value; }
        }

 
        private string? _Type = "";
        
        public string? Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }


        private string? _NullValue = "NO";
        
        public string? NullValue
        {
            get { return this._NullValue; }
            set { this._NullValue = value; }
        }


        private string? _Key = "";
        
        public string? Key
        {
            get { return this._Key; }
            set { this._Key = value; }
        }

        private string? _DefaultValue = "NO";
        
        public string? DefaultValue
        {
            get { return this.DefaultValue; }
            set { this.DefaultValue = value; }
        }
 
 

 



        #endregion


    }
}
