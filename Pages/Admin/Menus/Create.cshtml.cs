using Microsoft.AspNetCore.Mvc;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using MyOrangeCMS_RazorVersion.Service;
using MyOrangeCMS_RazorVersion.Data;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Menus
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
        public MenuDTO Menu { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid || _context.Menu == null || Menu == null)
            {
                return Page();
            }

            var menu      = new Menu();
            _context.Entry(menu).CurrentValues.SetValues(Menu);
            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}