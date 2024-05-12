using Microsoft.Extensions.Hosting;


namespace MyOrangeCMS_RazorVersion.Service
{
    public class FileTemplateService
    {
        
         
        private readonly IWebHostEnvironment? _hostEnvironment;
        public FileTemplateService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;

        }

        public string GetTemplateContent(string fileName){

            string path = _hostEnvironment.WebRootPath+"/template/"+fileName+".cs.html";
            string content = System.IO.File.ReadAllText(path);
            return content;
            
        }

        public string GetTemplateCodeValue(string actionName,string tableName){

            string content = this.GetTemplateContent(actionName);
            content = content.Replace("{{tableName}}",tableName);
            return content;
               


        }
 
    }
}
