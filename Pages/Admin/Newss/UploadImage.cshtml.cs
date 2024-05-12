using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Newss
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class UploadImageModel : PageModel
    {
        private readonly FileUploadService? _FileUploadService;
        public bool ShowDefaultJson { get; set; } = true;
        public UploadImageModel(FileUploadService fileUploadService)
        {

            _FileUploadService = fileUploadService;
             

        }
     

        public string DefaultJson = "{\r\n\t\"imageActionName\": \"uploadimage\",\r\n\t\"imageFieldName\": \"upfile\",\r\n\t\"imageMaxSize\": 2048000,\r\n\t\"imageAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\"],\r\n\t\"imageCompressEnable\": true,\r\n\t\"imageCompressBorder\": 1600,\r\n\t\"imageInsertAlign\": \"none\",\r\n\t\"imageUrlPrefix\": \"\",\r\n\t\"imagePathFormat\": \"/upload/image/{yyyy}{mm}{dd}/{time}{rand:6}\",\r\n\t\"scrawlActionName\": \"uploadscrawl\",\r\n\t\"scrawlFieldName\": \"upfile\",\r\n\t\"scrawlPathFormat\": \"/upload/image/{yyyy}{mm}{dd}/{time}{rand:6}\",\r\n\t\"scrawlMaxSize\": 2048000,\r\n\t\"scrawlUrlPrefix\": \"\",\r\n\t\"scrawlInsertAlign\": \"none\",\r\n\t\"snapscreenActionName\": \"uploadimage\",\r\n\t\"snapscreenPathFormat\": \"/upload/image/{yyyy}{mm}{dd}/{time}{rand:6}\",\r\n\t\"snapscreenUrlPrefix\": \"\",\r\n\t\"snapscreenInsertAlign\": \"none\",\r\n\t\"catcherLocalDomain\": [\"127.0.0.1\", \"localhost\", \"img.baidu.com\"],\r\n\t\"catcherActionName\": \"catchimage\",\r\n\t\"catcherFieldName\": \"source\",\r\n\t\"catcherPathFormat\": \"/upload/image/{yyyy}{mm}{dd}/{time}{rand:6}\",\r\n\t\"catcherUrlPrefix\": \"\",\r\n\t\"catcherMaxSize\": 2048000,\r\n\t\"catcherAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\"],\r\n\t\"videoActionName\": \"uploadvideo\",\r\n\t\"videoFieldName\": \"upfile\",\r\n\t\"videoPathFormat\": \"/upload/video/{yyyy}{mm}{dd}/{time}{rand:6}\",\r\n\t\"videoUrlPrefix\": \"\",\r\n\t\"videoMaxSize\": 102400000,\r\n\t\"fileActionName\": \"uploadfile\",\r\n\t\"fileFieldName\": \"upfile\",\r\n\t\"filePathFormat\": \"/upload/file/{yyyy}{mm}{dd}/{time}{rand:6}\",\r\n\t\"fileUrlPrefix\": \"\",\r\n\t\"fileMaxSize\": 51200000,\r\n\t\"fileAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\"],\r\n\t\"imageManagerActionName\": \"listimage\",\r\n\t\"imageManagerListPath\": \"/upload/image/\",\r\n\t\"imageManagerListSize\": 20,\r\n\t\"imageManagerUrlPrefix\": \"\",\r\n\t\"imageManagerInsertAlign\": \"none\",\r\n\t\"imageManagerAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\"],\r\n\t\"fileManagerActionName\": \"listfile\",\r\n\t\"fileManagerListPath\": \"/upload/file/\",\r\n\t\"fileManagerUrlPrefix\": \"\",\r\n\t\"fileManagerListSize\": 20,\r\n\t\"fileManagerAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\"]\r\n}";
        public string SuccessJson = "{\r\n    \"state\": \"SUCCESS\",\r\n\t\t\t\t\"url\": \"#filePath#\",\r\n\t\t\t\t\"title\": \"#fileName#\",\r\n\t\t\t\t\"original\": \"329238283_1443632529709095_4494408312701190580_n.jpg\",\r\n\t\t\t\t\"type\": \".jpg\",\r\n\t\t\t\t\"size\": 166049\r\n}";
        public async Task<IActionResult> OnGetAsync()
        {

            return Page();
        }
 

        public async Task<IActionResult> OnPostAsync(
            )
        {
            var files       = Request.Form.Files;
            string fileName = "";
            string aName    = "";
            foreach (var file in files)
            {

                aName        = file.FileName;
                fileName     = this._FileUploadService.Create(file);
                break;
                //file.CopyTo()
                  
            
            }

            this.SuccessJson = this.SuccessJson.Replace("#filePath#", fileName);
            this.SuccessJson = this.SuccessJson.Replace("#fileName#", aName);

            this.ShowDefaultJson = false ;
            return Page();

        }

      

    }
}
