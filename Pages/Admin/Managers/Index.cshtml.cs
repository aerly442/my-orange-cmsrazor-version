using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Managers
{

    public class IndexModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersion.Data.MyOrangeCMS_RazorVersionContext _context;

        private readonly IMapper _mapper;
        public IndexModel(MyOrangeCMS_RazorVersion.Data.MyOrangeCMS_RazorVersionContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
           // this.ViewData["MyLeftMenu"] = "abc";
        }

        public IList<ManagerDTO> Manager { get;set; } = default!;

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

            if (_context.Manager != null)
            {
 

                string where   = string.IsNullOrEmpty(SearchDTO.SearchValue)?"Id>0": SearchDTO.FieldName + ".contains(\"" + SearchDTO.SearchValue + "\")";
                var q          =  _context.Manager.Where(where);
                TotalCount     = await q.CountAsync();
                int skip       = MyPage.GetSkip(MyPageNumber, MyPage.PageSize); 
                var lst        = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
                this.Manager   = _mapper.Map<List<ManagerDTO>>(lst);
                this.SplitPageHtml = MyPage.GetSplitPageHtml(TotalCount, MyPageNumber, MyPage.PageSize);
            }

        }

        public async Task OnGetAsync()
        {


 
            if (_context.Manager != null)
            {
                TotalCount   = await _context.Manager.CountAsync();
                var lst      = await _context.Manager.OrderByDescending(x => x.Id).Take(MyPage.PageSize).ToListAsync();
               
                this.Manager = _mapper.Map<List<ManagerDTO>>(lst);

                this.SplitPageHtml = MyPage.GetSplitPageHtml(TotalCount,1, MyPage.PageSize);
            }
        }
    }
}
