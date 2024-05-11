using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Service;


namespace MyOrangeCMS_RazorVersion.Pages.Article
{
    public class ShowModel : PageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private IMapper _mapper;

        public ShowModel(MyOrangeCMS_RazorVersionContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        [BindProperty]
        public NewsDTO News { get; set; } = default!;

        //资源内容
        public String Resource { get; set; } = default!;


        private async Task<String> GetResource(int newsId)
        {

            var s =  from rlist in _context.News_resource_list
                   join news in _context.News on rlist.Newsid equals news.Id
                   join source in _context.News_resource on rlist.Newsresourceid equals source.Id
                   where news.Id == newsId
                   select new 
                   {
                       Resource = source.Resource
                       
                   };
            var lst = await s.ToListAsync();
            return lst != null && lst.Count > 0 ? lst[0].Resource : "";

        }


        public bool ShowDownLoadDlg {get;set;}

        ///内容支付对话框
        public bool ShowContentChargeDlg {get;set;}

        private bool GetContentCharge(NewsDTO news){

            return news.Price>0 && news.Is_charge ==1 && news.Charge_type == 0?true:false;

        }

        private bool GetDownLoadCharge(string resource ,NewsDTO news){

            return resource !="" && news.Price>0 && news.Is_charge ==1 && news.Charge_type == 1?true:false;

        }


        public string Content {get;set;}

        //已经支付费用
        private bool HasPay(int newsId){

            return true ;
        }
        //是否需要全文显示：无需付费或者已经支付
        public bool CanShowFullContent {get;set;}
        private string GetContent(bool blnCharge,NewsDTO news){
          
          if (blnCharge == false || this.HasPay(news.Id)){
              this.CanShowFullContent = true ;
              return news.Content;
          }
          else{
            
             string content = NewsService.ClearHtml(news.Content);
             content = content.Substring(0,content.Length/3);
             this.CanShowFullContent = false ;
             return "<p>"+content+"</p>";

          }


        }

        public bool CanShowResource {get;set;}
        //是否需要显示资源：已经支付或者不收费
        private bool ShowResource(bool blnCharge,NewsDTO news){

            if (blnCharge == false || this.HasPay(news.Id)){
                return true;
            };
            
            return false;


        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var news = await _context.News.FirstOrDefaultAsync(x => x.Id == id && x.State == 1);
            if (news == null)
            {
                return NotFound();
            }
            else
            {
                news.Visit    = news.Visit + 1;
                await _context.SaveChangesAsync();
                News                      = _mapper.Map<NewsDTO>(news);

                this.Resource             = await this.GetResource((int)id);
                this.ShowDownLoadDlg      = true;// this.GetDownLoadCharge(this.Resource,News);  //this.Resource ==""?"none":"";
                this.ShowContentChargeDlg = this.GetContentCharge(News);
                //文章正文内容  
                this.Content              = this.GetContent(this.ShowContentChargeDlg,News);
                //是否显示下载资源:无需付费或者已经支付
                this.CanShowResource      = true ; //this.ShowResource(this.ShowDownLoadDlg,News);
                //this.Model.ShowDownLoadDlg && this.Model.CanShowResource

                

            }
            return Page();
        }

    }
}
