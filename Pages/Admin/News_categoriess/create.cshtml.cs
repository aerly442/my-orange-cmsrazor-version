using Microsoft.AspNetCore.Mvc;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;
using MyOrangeCMS_RazorVersion.Data;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_categoriess
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
        public News_categoriesDTO News_categories { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid || _context.News_categories == null || News_categories == null)
            {
                return Page();
            }

            var news_categories      = new News_categories();
            _context.Entry(news_categories).CurrentValues.SetValues(News_categories);
            _context.News_categories.Add(news_categories);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}