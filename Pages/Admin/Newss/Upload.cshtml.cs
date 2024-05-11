using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;
using Microsoft.AspNetCore.Hosting;
using MyOrangeCMS_RazorVersion.Service;

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Newss
{
    public class UploadModel : PageModel
    {
        private readonly FileUploadService? _FileUploadService;
        public UploadModel(FileUploadService fileUploadService)
        {

            _FileUploadService = fileUploadService;
            this.ShowScript    = false;
            //this.ExtName       = FileUploadService.ext; 

        }

        [BindProperty]
        public String? ParentControlId { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(string? id= "")
        {
            this.ParentControlId = id;
            return Page();
        }

        [BindProperty]
        public IFormFile? Photo { get; set; }

        [BindProperty]
        public bool ShowScript { get; set; }

        [BindProperty]
        public String ?UploadFileName { get; set; }

    


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (this.Photo != null)
            {
                string fileName     = this._FileUploadService?.Create(this.Photo);
                this.ShowScript     = !string.IsNullOrEmpty(fileName);
                this.UploadFileName = fileName;
            }
             return Page();
      
        }

    }
}
