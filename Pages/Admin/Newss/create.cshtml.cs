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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Newss
{
    public class CreateModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly NewsService _newsService;

        public CreateModel(MyOrangeCMS_RazorVersionContext context,
             NewsService newsService)
        {
          
            _context = context;
            this._newsService = newsService;
        }

           
        public async Task<IActionResult> OnGet()
        {   
            lstCat = await this._newsService.GetListNewsCat();
            return Page();
        }

        [BindProperty]
        public NewsDTO News { get; set; } = default!;
        public List<SelectListItem>? lstCat { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid || _context.News == null || News == null)
            {                
                return Page();
            }

            var news      = new News();
            _context.Entry(news).CurrentValues.SetValues(News);
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}