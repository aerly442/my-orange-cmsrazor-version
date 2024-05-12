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

using System.Linq.Dynamic.Core;


namespace MyOrangeCMS_RazorVersion.Pages.Admin.Newss
{

    public class IndexModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        private readonly IMapper _mapper;
        private readonly NewsService _newsService;
        public IndexModel(MyOrangeCMS_RazorVersionContext context,
            IMapper mapper,
            NewsService newsService)
        {
            _context = context;
            _mapper  = mapper;
            _newsService = newsService ;
     
        }

        public IList<NewsDTO> News { get;set; } = default!;

        [BindProperty]
        public SearchDTO SearchDTO { get; set; } = default!;

        [BindProperty]
        public int MyPageNumber { get; set; } = 1;

        [BindProperty]
        public string MyActionType { get; set; } = "";

        //[BindProperty]
        public int TotalCount { get; set; } = 0;

        public string SplitPageHtml { get; set; } = "";

        public List<SelectListItem>? lstCat { get; set; }

        [BindProperty]  
        public string CatCode {get;set;}

        private void SetCatCode(){

             string code = this.Request.Query["code"];
             if (String.IsNullOrEmpty(code) == false ){

                 this.CatCode = code ; 

             }


  


        }

        public async Task OnPostAsync()
        {

            if (_context.News != null)
            {
                //设置查询栏目
                this.lstCat = await this._newsService.GetListNewsCat();
                this.lstCat.Insert(0,new SelectListItem("请选择",""));

                string where   = string.IsNullOrEmpty(SearchDTO.SearchValue)?"Id>0": SearchDTO.FieldName + ".contains(\"" + SearchDTO.SearchValue + "\")";
                 if (String.IsNullOrEmpty(this.CatCode) == false ){
                    where      += " and News_categories_code.contains(\""+this.CatCode+"\")";   
                }
                var query      = this._newsService.GetNewsQuery() ; 
                var q          = query.Where(where);

                TotalCount     = await q.CountAsync();
                int skip       = MyPage.GetSkip(MyPageNumber, MyPage.PageSize); 
                var lst        = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
                this.News      = _mapper.Map<List<NewsDTO>>(lst);

                this.SplitPageHtml = MyPage.GetSplitPageHtml(TotalCount, MyPageNumber, MyPage.PageSize);
            }

        }

        public async Task OnGetAsync()
        {

            if (_context.News != null)
            {
                //设置查询栏目
                this.SetCatCode();
                this.lstCat = await this._newsService.GetListNewsCat();
                this.lstCat.Insert(0,new SelectListItem("请选择",""));

                TotalCount   = await _context.News.CountAsync();
                var query    = this._newsService.GetNewsQuery() ; 
                string where = "News_categories_code.contains(\""+this.CatCode+"\")";
                var q        = string.IsNullOrEmpty(this.CatCode)?query:query.Where(where);
                var lst      = await q.OrderByDescending(x => x.Id).Take(MyPage.PageSize).ToListAsync();
            
                this.News = _mapper.Map<List<NewsDTO>>(lst);

                this.SplitPageHtml = MyPage.GetSplitPageHtml(TotalCount,1, MyPage.PageSize);
            }
        }
    }
}