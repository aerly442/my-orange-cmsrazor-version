using Microsoft.AspNetCore.Mvc;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;
using MyOrangeCMS_RazorVersion.Data;
using AutoMapper;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.DTO;


namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_resource_lists
{
    public class DeleteModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private IMapper _mapper;

        private readonly NewsService _newsService;
        public DeleteModel(MyOrangeCMS_RazorVersionContext context,
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
            var q = _newsService.GetNewsResourceQuery();
            var news_resource_list = await q.FirstOrDefaultAsync(m => m.Id == id);

            if (news_resource_list == null)
            {
                return NotFound();
            }
            else 
            {
                News_resource_list = news_resource_list ;// _mapper.Map<News_resource_listDTO>(news_resource_list);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.News_resource_list == null)
            {
                return NotFound();
            }
            var news_resource_list = await _context.News_resource_list.FindAsync(id);

            if (news_resource_list != null)
            {
               // Manager = manager;
                _context.News_resource_list.Remove(news_resource_list);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}