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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_order_lists
{

    public class EditModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        private readonly IMapper _mapper;

        public EditModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
        {
            _context     = context;
            this._mapper = _mapper;
        }

        [BindProperty]
        public News_order_listDTO News_order_list { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_order_list == null)
            {
                return NotFound();
            }

            var news_order_list = id ==0 ? new News_order_list():await _context.News_order_list.FirstOrDefaultAsync(m => m.Id == id);
            if (news_order_list == null)
            {
                return NotFound();
            }
            News_order_list = _mapper.Map<News_order_listDTO>(news_order_list);
            return Page();
        }

 

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id      = News_order_list.Id;
            var news_order_list = id ==0 ? new News_order_list():await _context.News_order_list.FirstOrDefaultAsync<News_order_list>(m => m.Id == id);
            if (news_order_list == null)
            {
                return NotFound();

            }

      

            _context.Entry(news_order_list).CurrentValues.SetValues(News_order_list);
            

            try
            {
                if (id == 0 ) _context.Add(news_order_list);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_order_listExists(News_order_list.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool News_order_listExists(int id)
        {
          return (_context.News_order_list?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}