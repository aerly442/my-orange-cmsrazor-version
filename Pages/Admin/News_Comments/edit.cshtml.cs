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

 namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_comments
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
        public News_commentDTO News_comment { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var data    = id == 0 ? new News_comment() : await _context.News_comment.FirstOrDefaultAsync(m => m.Id == id);
            //this.lstCat = await this._newsService.GetListNewsCat();
            if (data == null)
            {
                return NotFound();
            }
            News_comment = _mapper.Map<News_commentDTO>(data);

            return Page();
            }
            public async Task<IActionResult> OnPostAsync()
            {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = News_comment.Id;
            var data = id == 0 ? new News_comment() : await _context.News_comment.FirstOrDefaultAsync<News_comment>(m => m.Id == id);

            _context.Entry(data).CurrentValues.SetValues(News_comment);


            try
            {
                if (id == 0)
                {
                    //user_authorize_code.Createtime = DateTime.Now;
                    //user_authorize_code
                    _context.News_comment.Add(data);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!News_commentExists(News_comment.Id))
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

        private bool News_commentExists(int id)
        {
            return (_context.News_comment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
     }
 }
