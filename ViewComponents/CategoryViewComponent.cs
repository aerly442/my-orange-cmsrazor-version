using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.Models;
using Microsoft.EntityFrameworkCore;

namespace MyOrangeCMS_RazorVersion.ViewComponents
{
    [ViewComponent(Name = "Category")]
    public class CategoryViewComponent : ViewComponent
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public CategoryViewComponent(MyOrangeCMS_RazorVersionContext context) => _context = context;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<string> categories = new List<string>() {
                "category 1", "category 2", "category 3", "category 4", "category 5"
            };
            List<Manager> lst = await _context.Manager.ToListAsync<Manager>(); 
            return View("/Pages/Components/LeftMenu.cshtml", categories);
        }
 
    }
}
