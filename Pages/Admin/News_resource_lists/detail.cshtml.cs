using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;
using MyOrangeCMS_RazorVersion.Data;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_resource_lists
{
    public class DetailModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private IMapper _mapper;

        private readonly NewsService _newsService;
        public DetailModel(MyOrangeCMS_RazorVersionContext context,
            IMapper mapper, NewsService newsService)
        {
            _context = context;
            _mapper = mapper;
            _newsService = newsService;

        }

        [BindProperty]
        public News_resource_listDTO News_resource_list { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_resource_list == null)
            {
                return NotFound();
            }

            var news_resource_list = await _context.News_resource_list.FirstOrDefaultAsync(m => m.Id == id);
            if (news_resource_list == null)
            {
                return NotFound();
            }
            else 
            {
                News_resource_list = _mapper.Map<News_resource_listDTO>(news_resource_list);
            }
            return Page();
        }
    }
}