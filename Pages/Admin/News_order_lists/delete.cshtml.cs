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


namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_order_lists
{
    public class DeleteModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private IMapper _mapper;

        public DeleteModel(MyOrangeCMS_RazorVersionContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        [BindProperty]
        public News_order_listDTO News_order_list { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_order_list == null)
            {
                return NotFound();
            }

            var news_order_list = await _context.News_order_list.FirstOrDefaultAsync(m => m.Id == id);

            if (news_order_list == null)
            {
                return NotFound();
            }
            else 
            {
                News_order_list = _mapper.Map<News_order_listDTO>(news_order_list);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.News_order_list == null)
            {
                return NotFound();
            }
            var news_order_list = await _context.News_order_list.FindAsync(id);

            if (news_order_list != null)
            {
               // Manager = manager;
                _context.News_order_list.Remove(news_order_list);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}