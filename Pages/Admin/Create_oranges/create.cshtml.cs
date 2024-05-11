using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;
using MyOrangeCMS_RazorVersion.Data;
using System.Text;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Create_oranges
{

    public class CreateModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly NewsService _newsService;
        private readonly FileTemplateService _fileTemplateService;


        private readonly IMapper _mapper;

        public CreateModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,
          NewsService newsService,
          FileTemplateService fileTemplateService
        )
        {
            _context     = context;
            this._mapper = _mapper;
            this._newsService = newsService;
            this._fileTemplateService = fileTemplateService;
        }


        public string SuccessJson{get;set;}
     
        public List<TableDescDTO> lstTable {get;set;}

 
        private  string GetFieldType(TableDescDTO t,ref string defaultValue)
        {
             
             string value = "string";
             if (t.Type.IndexOf("int")>=0){
                 value = "int";
                 defaultValue = "0";
             }
             else if (t.Type.IndexOf("datetime")>=0){
                 value = "DateTime";
                 defaultValue = "DateTime.Now";
             }
             else{

                 value = "string";
                 defaultValue = "\"\"";
                 if (t.NullValue =="YES" ){
                    value +="?";
                 };
             };


             
             return value;

        }

        private string GetFieldName(string field){

            string s = field;
            return s.Substring(0,1).ToUpper()+s.Substring(1); 
        }

        private string GetModelAndDto(string field,string defaultValue,
           string type, string aType,string tableName,TableDescDTO t){
               
            StringBuilder sb = new StringBuilder();
            sb.Append("private "+type+" _"+field+" = "+defaultValue+";\r");
            if (aType =="dto"){
                sb.Append(" [Display(Name = \""+field+"\")]\r");     
                if (t.NullValue=="NO"){                
                    sb.Append("[Required(ErrorMessage = \""+field+"是必须\")]\r");
                }
            }
            sb.Append("public "+type+" "+field+"\r");
            sb.Append("{\r");
            sb.Append("get { return this._"+field+"; }\r");
            sb.Append("set { this._"+field+" = value; }\r");
            sb.Append("}\r");

            return sb.ToString();

        }


        private string GetHtml(string field,string defaultValue,
           string type, string aType,string tableName,TableDescDTO t){
               
            StringBuilder sb = new StringBuilder();
            
            if (aType=="index-th"){

   
                sb.Append("<th>\r");
                sb.Append("     @Html.DisplayNameFor(model => model."+tableName+"[0]."+field+")\r");
                sb.Append("</th>" +"\r");

            }
            else if (aType=="index-td"){
              
                sb.Append("<td>\r");
                sb.Append("     @Html.DisplayFor(modelItem => item."+field+")\r");
                sb.Append("</td>" +"\r");

            }
            else if (aType=="edit"){

               // sb.Append("<!-- edit.cshtml -->\r");
                sb.Append("<div class=\"form-group\">\r");
                sb.AppendFormat("    <label asp-for=\"{0}.{1}\" class=\"col-sm-2 control-label\"></label>\r",tableName,field);
                sb.AppendFormat("    <input asp-for=\"{0}.{1}\" class=\"form-control\" style=\"width:30%;\" />\r",tableName,field);
                
                sb.Append("</div>\r");
                sb.Append("<div class=\"row div-error\">\r");
                sb.Append("  <label class=\"col-sm-2 control-label\">&nbsp;</label>\r");
                sb.AppendFormat("  <span asp-validation-for=\"{0}.{1}\" class=\"text-danger\"></span>\r",tableName,field);
                sb.Append("</div>\r");
            }
            else if (aType=="detail")
            {

                //sb.Append("<!-- detail.cshtml -->\r");
                sb.Append("<div class=\"form-group\">\r");
                sb.Append("  <label class=\"col-md-2 \">\r");
                sb.AppendFormat("        @Html.DisplayNameFor(model => model.{0}.{1})\r",tableName,field);
                sb.Append("  </label>\r");
                sb.Append("  <div class=\"col-md-10\">\r");
                sb.Append("   <span class=\"text-default\">\r");
                sb.AppendFormat("         @Html.DisplayFor(model =>model.{0}.{1})\r",tableName,field);
                sb.Append("   </span>\r");
                sb.Append(" </div>\r");
                sb.Append("</div>\r");
            }
             

            return sb.ToString();

        }

        public delegate string DelegateGetCodeFromTeplate(string field,string defaultValue,
           string type, string aType,string tableName,TableDescDTO t);

        //private DelegateGetCodeFromTeplate GetCodeFromTeplate = new DelegateGetCodeFromTeplate();
        private string GetCodeValue(DelegateGetCodeFromTeplate getValue,string tableName,string aType){

            StringBuilder sb = new StringBuilder();
            foreach(var t in this.lstTable){

                string field        = this.GetFieldName(t.Field);
                string defaultValue = "";
                string type         = this.GetFieldType(t,ref defaultValue);
                tableName           = this.GetFieldName(tableName);
                string  codeValue   = getValue( field, defaultValue,type,  aType, tableName, t);              
                sb.Append(codeValue);

 

            };
            return sb.ToString();

        }
         
        
        public async Task<IActionResult> OnGetAsync(String tableName,string aType="model")
        {     
            this.lstTable    = this._newsService.GetTableInfo(tableName);  
            string codeValue = "";
     
                if (aType =="dto" ||aType =="model"){

                    codeValue = this.GetCodeValue(GetModelAndDto,tableName,aType);

                 }
                else if (aType=="html"){
                    codeValue  = "\r<!-- index.cshtml -th -->\r";
                    codeValue += this.GetCodeValue(GetHtml,tableName,"index-th");
                    codeValue += "\r<!-- index.cshtml -td -->\r";
                    codeValue += this.GetCodeValue(GetHtml,tableName,"index-td");
                    codeValue += "\r<!-- detail.cshtml -->\r";
                    codeValue += this.GetCodeValue(GetHtml,tableName,"detail");
                    codeValue += "\r<!-- edit.cshtml  -->\r";
                    codeValue += this.GetCodeValue(GetHtml,tableName,"edit");
                }
                else if (aType =="cs"){
                    codeValue = "\r<!-- Index.cshtml.cs  -->\r";
                    codeValue += this._fileTemplateService.GetTemplateCodeValue("Index",this.GetFieldName(tableName));
                    codeValue += "\r<!-- Edit.cshtml.cs  -->\r";
                    codeValue += this._fileTemplateService.GetTemplateCodeValue("Edit",this.GetFieldName(tableName));
                    codeValue += "\r<!-- Delete.cshtml.cs  -->\r";
                    codeValue += this._fileTemplateService.GetTemplateCodeValue("Delete",this.GetFieldName(tableName));
                    codeValue += "\r<!-- Detail.cshtml.cs  -->\r";
                    codeValue += this._fileTemplateService.GetTemplateCodeValue("Detail",this.GetFieldName(tableName));
                }
         
            this.SuccessJson = codeValue;

            
            
            return Page();
        }
        
 
 
 
    }


}