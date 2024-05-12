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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_resource_lists
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
        public News_resource_listDTO News_resource_list { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News_resource_list == null)
            {
                return NotFound();
            }

            var news_resource_list = id == 0 ? new News_resource_list():await _context.News_resource_list.FirstOrDefaultAsync(m => m.Id == id);
            if (news_resource_list == null)
            {
                return NotFound();
            }
            News_resource_list = _mapper.Map<News_resource_listDTO>(news_resource_list);
            return Page();
        }

 
        public string ErrorInfo {get;set;}

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id      = News_resource_list.Id;
            var news_resource_list = id == 0 ?new News_resource_list():await _context.News_resource_list.FirstOrDefaultAsync<News_resource_list>(m => m.Id == id);
            if (news_resource_list == null )
            {
                return NotFound();

            }

            if (this.News_resource_listExists((int)this.News_resource_list.Newsid,(int)this.News_resource_list.Newsresourceid))
            {

                this.ErrorInfo = ShowInfoService.Show(false,"选择的数据已存在") ;
                return Page();
            }
      

            _context.Entry(news_resource_list).CurrentValues.SetValues(News_resource_list);
            

            try
            {
                if (id == 0) _context.Add(news_resource_list);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_resource_listExists(News_resource_list.Id))
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

        private bool News_resource_listExists(int id)
        {
          return (_context.News_resource_list?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool News_resource_listExists(int newsId,int resourceId){
           return (_context.News_resource_list?.Any(e => e.Newsid == newsId && e.Newsresourceid==resourceId)).GetValueOrDefault(); 
        }
    }
}