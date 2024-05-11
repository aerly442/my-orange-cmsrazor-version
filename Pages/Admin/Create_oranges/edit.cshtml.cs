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

namespace MyOrangeCMS_RazorVersion.Pages.Admin.Create_oranges
{

    public class EditModel : BasePageModel
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly NewsService _newsService;

        private readonly IMapper _mapper;

        public EditModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,
          NewsService newsService
        )
        {
            _context     = context;
            this._mapper = _mapper;
            this._newsService = newsService;
        }

        public List<SelectListItem>? lstTable { get; set; }
       // [BindProperty]
       // public Film_dataDTO Film_data { get; set; } = default!;


        [BindProperty]
        public String  TableName { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {       
            this.lstTable = this._newsService.GetTable();
            return Page();
        }

 

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        
        public async Task<IActionResult> OnPostAsync()
        {

              
            return Page(); 
           
        }
   
 
    }
}