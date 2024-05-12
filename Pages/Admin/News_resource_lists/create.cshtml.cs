using Microsoft.AspNetCore.Mvc;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;
using MyOrangeCMS_RazorVersion.Data;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_resource_lists
{
    public class CreateModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public CreateModel(MyOrangeCMS_RazorVersionContext context)
        {
          
            _context = context;
        }

           
        public IActionResult OnGet()
        {           
            return Page();
        }

        [BindProperty]
        public News_resource_listDTO News_resource_list { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid || _context.News_resource_list == null || News_resource_list == null)
            {
                return Page();
            }

            var news_resource_list      = new News_resource_list();
            _context.Entry(news_resource_list).CurrentValues.SetValues(News_resource_list);
            _context.News_resource_list.Add(news_resource_list);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}