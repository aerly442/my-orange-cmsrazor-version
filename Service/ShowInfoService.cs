using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;

namespace MyOrangeCMS_RazorVersion.Service
{


    public class ShowInfoService
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public ShowInfoService(MyOrangeCMS_RazorVersionContext context)
        {

            _context = context;
        }



        public static string Show(bool blnSuccess,string errorInfo)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string  style = blnSuccess?"success":"danger";
            sb.AppendFormat("<div class=\"alert alert-{0} \" id=\"divHidden\" >",style);
            sb.Append(errorInfo);
            sb.Append("</div>");
            return sb.ToString();
            
        }

    
    }
}