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


using System.Linq.Dynamic.Core;

 namespace MyOrangeCMS_RazorVersion.Pages.Admin.News_resource_lists
 {
      public class SelectModel : BasePageModel
     {
         private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;
        private readonly News_resourceService _news_ResourceService;
        public SelectModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,
           News_resourceService news_resourceService
        )
         {
             _context     = context;
             this._mapper = _mapper;
             this._news_ResourceService = news_resourceService;
         }
        


         public IList<News_resource_infoDTO> News_resource_list { get;set; } = default!;


        [BindProperty]
        public SearchDTO SearchDTO { get; set; } = default!;

        [BindProperty]
        public string Type {get;set;}
        public async Task OnGetAsync()
         {
             
            if (_context.News_resource_list != null)
            {
                string type =  this.Request.Query["type"];
                this.Type   = !string.IsNullOrEmpty(type) && type == "1"?"1":"2" ;
                var query   = this._news_ResourceService.GetQuery(type);
                var lst     = query.OrderByDescending(x => x.Id).Take(MyPage.PageSize).ToList();
                this.News_resource_list = lst;

                
            }
         }
        public async Task OnPostAsync()
         {
            if (_context.News_resource_list != null)
            {
 
                string where   = string.IsNullOrEmpty(SearchDTO.SearchValue)?"Id>0": SearchDTO.FieldName + ".contains(\"" + SearchDTO.SearchValue + "\")";
                var query      = this._news_ResourceService.GetQuery(this.Type);
                var q          = query.Where(where);
                var lst        = await q.OrderByDescending(x => x.Id).Take(MyPage.PageSize).ToListAsync();
                this.News_resource_list   = lst;
               
            }
         }
       
       }
 }
