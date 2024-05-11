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


namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_tags
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
        public News_tagDTO News_tag { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_tag == null)
            {
                return NotFound();
            }

            var news_tag = await _context.News_tag.FirstOrDefaultAsync(m => m.Id == id);

            if (news_tag == null)
            {
                return NotFound();
            }
            else 
            {
                News_tag = _mapper.Map<News_tagDTO>(news_tag);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.News_tag == null)
            {
                return NotFound();
            }
            var news_tag = await _context.News_tag.FindAsync(id);

            if (news_tag != null)
            {
               // Manager = manager;
                _context.News_tag.Remove(news_tag);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}