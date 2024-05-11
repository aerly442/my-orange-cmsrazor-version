using Microsoft.AspNetCore.Mvc;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;
using MyOrangeCMS_RazorVersion.Data;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_resources
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
        public News_resourceDTO News_resource { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid || _context.News_resource == null || News_resource == null)
            {
                return Page();
            }

            var news_resource      = new News_resource();
            _context.Entry(news_resource).CurrentValues.SetValues(News_resource);
            _context.News_resource.Add(news_resource);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}