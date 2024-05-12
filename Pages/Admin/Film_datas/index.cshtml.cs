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


namespace MyOrangeCMS_RazorVersion.Pages.Admin.Film_datas
{

    public class IndexModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        private readonly IMapper _mapper;
        public IndexModel(MyOrangeCMS_RazorVersionContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
     
        }

        public IList<Film_dataDTO> Film_data { get;set; } = default!;

        [BindProperty]
        public SearchDTO SearchDTO { get; set; } = default!;

        [BindProperty]
        public int MyPageNumber { get; set; } = 1;

        [BindProperty]
        public string MyActionType { get; set; } = "";

        //[BindProperty]
        public int TotalCount { get; set; } = 0;

        public string SplitPageHtml { get; set; } = "";

        public async Task OnPostAsync()
        {

            if (_context.Film_data != null)
            {
 

                string where   = string.IsNullOrEmpty(SearchDTO.SearchValue)?"Id>0": SearchDTO.FieldName + ".contains(\"" + SearchDTO.SearchValue + "\")";
                var q          =  _context.Film_data.Where(where);
                TotalCount     = await q.CountAsync();
                int skip       = MyPage.GetSkip(MyPageNumber, MyPage.PageSize); 
                var lst        = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
                this.Film_data   = _mapper.Map<List<Film_dataDTO>>(lst);
                this.SplitPageHtml = MyPage.GetSplitPageHtml(TotalCount, MyPageNumber, MyPage.PageSize);
            }

        }

        public async Task OnGetAsync()
        {


 
            if (_context.Film_data != null)
            {
                TotalCount   = await _context.Film_data.CountAsync();
                var lst      = await _context.Film_data.OrderByDescending(x => x.Id).Take(MyPage.PageSize).ToListAsync();
               
                this.Film_data = _mapper.Map<List<Film_dataDTO>>(lst);

                this.SplitPageHtml = MyPage.GetSplitPageHtml(TotalCount,1, MyPage.PageSize);
            }
        }
    }
}