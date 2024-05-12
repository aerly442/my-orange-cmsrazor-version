using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using System.Web;

namespace MyOrangeCMS_RazorVersion.Pages.Front
{
    public class GetIndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;


        private readonly MyOrangeCMS_RazorVersionContext _context;

        private readonly IMapper _mapper;
        public GetIndexModel(MyOrangeCMS_RazorVersionContext context,
            IMapper mapper,
            ILogger<IndexModel> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;

        }

        public List<NewsDTO> lstNews { get; set; }

        private string GetSearchString(string key)
        {
            if (this.Request.Query[key].Count > 0)
            {
                string code =  this.Request.Query[key].ToString();
                code        =  HttpUtility.UrlDecode(code);
                if (code.Length > 20)
                {
                    code = code.Substring(0, 20);
                }
                return code;
            }

            return "";


        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? p)
        {
            int pageSize  = 10;
            int nPage     = (int) (p == null ? 1 : p);
            int skip      = MyPage.GetSkip(nPage, pageSize);
            var query     =  _context.News.Where(x => x.State == 1);

            string code = this.GetSearchString("code");
            if (code != "")
            {
                if (code.Length > 3)
                {
                    query = query.Where(x => x.News_categories_code ==code);
                }
                else
                {
                    query = query.Where(x => x.News_categories_code.StartsWith(code));
                }
            }

            string tag = this.GetSearchString("tag");
            if (tag != "")
            {
                query = query.Where(x => x.Key_word.Contains(tag));
            }

            string keyword = this.GetSearchString("keyword");
            if (keyword != "")
            {
                query = query.Where(x => x.Title.Contains(keyword));
            }

            List<News> lst = await query.OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).Select(x =>
                 new News
                 {
                     Id    = x.Id,
                     Title = x.Title,
                     Key_word = x.Key_word,
                     Abstract = x.Abstract,
                     Createtime = x.Createtime,
                     Mainpic = x.Mainpic
                 }
                ).ToListAsync();

            this.lstNews = _mapper.Map<List<NewsDTO>>(lst);

            return Page();

        }
    }
}
