using Microsoft.AspNetCore.Mvc;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.Models;

namespace MyOrangeCMS_RazorVersion.ViewComponents
{
    [ViewComponent(Name = "FrontTopMenu")]
    public class FrontTopMenuViewComponent:ViewComponent
    {

        private readonly MyOrangeCMS_RazorVersionContext _context;

        public FrontTopMenuViewComponent(MyOrangeCMS_RazorVersionContext context) => _context = context;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Pages/Components/FrontTopMenu.cshtml");
        }
    }
}
