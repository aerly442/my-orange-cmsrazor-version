using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;

namespace MyOrangeCMS_RazorVersion.Pages.Article
{
    public class ListAllModel : PageModel
    {
        //[BindProperty]
        //分类代码
        public string Code { get; set; } = "001";
        //[BindProperty]
        //标枪
        public string Tag { get; set; } = "";

        //[BindProperty]
        //关键词
        public string Keyword { get; set; } = "";

        public List<News_categories> lstSubCat { get; set; } = default!;

        private readonly MyOrangeCMS_RazorVersionContext _context;
        private IMapper _mapper;

        public ListAllModel(MyOrangeCMS_RazorVersionContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (this.Request != null && this.Request.Query != null &&
                this.Request.Query["code"].Count > 0)
            {
                this.Code = this.Request.Query["code"].ToString();
            }

            if (this.Request != null && this.Request.Query != null &&
                this.Request.Query["Tag"].Count > 0)
            {
                this.Tag = this.Request.Query["Tag"].ToString();
            }

            if (this.Request != null && this.Request.Query != null &&
                    this.Request.Query["Keyword"].Count > 0)
            {
                this.Keyword = this.Request.Query["Keyword"].ToString();
            }

            this.SetLstSubCat(this.Code);

            return Page();
        }

        /// <summary>
        /// 设置子菜单
        /// </summary>
        /// <param name="code"></param>
        private void SetLstSubCat(string code)
        {
            if (string.IsNullOrEmpty(code) == false )
            {
                string[] aryCode = code.Split('.');
                string   aCode   = aryCode[0];
                this.lstSubCat    = _context.News_categories.Where(x => x.Code.StartsWith(aCode + ".")).ToList();
            }

        }

      
    }
}
