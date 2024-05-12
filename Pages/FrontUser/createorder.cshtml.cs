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

 using System.Security.Claims;

 namespace MyOrangeCMS_RazorVersion.Pages.FrontUser
 {

      [IgnoreAntiforgeryToken(Order = 1001)]
      public class CreateOrderModel : PageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;
        private readonly News_order_listService _News_order_listService;
        public CreateOrderModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper,
        News_order_listService news_order_listService
        )
         {
             _context     = context;
             this._mapper = _mapper;
             this._News_order_listService = news_order_listService ;
         }
        
        //[BindProperty]
        public News_order_listDTO UserOrder{ get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            string userId  = this.GetRequest("userId");
            string newsId  = this.GetRequest("newsId");

            var uid          = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var role         = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;       
            var nickName     = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            bool isLogin     = (uid!=null && uid == userId  && role =="FrontUser");

            UserOrder = new News_order_listDTO();
            

           

            int aNewsId = 0;
            int.TryParse(newsId ,out aNewsId);

            int aUserId = 0;
            int.TryParse(userId,out aUserId);

            if (isLogin && aNewsId>0 && aUserId>0){

                var order = this._News_order_listService.AddOrder(aNewsId,aUserId);
                if (order!=null){
                    UserOrder = _mapper.Map<News_order_listDTO>(order);
                }

            }
            

            return Page();
        }

         private string GetRequest(string key){

            if (this.Request != null && this.Request.Query != null &&
                this.Request.Query[key].Count > 0)
            {
                return this.Request.Query[key].ToString();
            }
            return "";

         }
        
        public async Task<IActionResult> OnPostAsync()
        {
           return Page();
        }
       }
 }
