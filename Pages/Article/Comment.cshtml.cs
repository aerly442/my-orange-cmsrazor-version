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

 using System.Linq.Dynamic.Core;

 namespace MyOrangeCMS_RazorVersion.Pages.Article
 {
      [IgnoreAntiforgeryToken(Order = 1001)]
      public class CommentModel : PageModel
     {
        private readonly MyOrangeCMS_RazorVersionContext _context;
        private readonly IMapper _mapper;
        public CommentModel(MyOrangeCMS_RazorVersionContext context, IMapper _mapper)
        {
             _context     = context;
             this._mapper = _mapper;
        }
        public List<News_commentDTO> lstComment { get; set; } = default!;

        public string ErrorInfo {get;set;}

        private async Task<List<News_commentDTO>> GetCommentList(int? id){

             string where       = id==null?"newsid=0":"newsid="+((int)id).ToString()+" and state=1";
             var q              =  _context.News_comment.Where(where);
             var lst            = await q.OrderByDescending(x => x.Id ).ToListAsync();
             return             _mapper.Map<List<News_commentDTO>>(lst);

        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {

             this.lstComment            = await this.GetCommentList(id);
             return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
              
             try{

               string  aUserId  =  Request.Form["userId"];
               string  content  =  Request.Form["content"];
               string  newsId   =  Request.Form["newsId"];
              
               var userId       = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
               var role         = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
               
               bool isLogin     = (userId!=null  && userId==aUserId && role =="FrontUser");

               var mUserid      = 0;
               int.TryParse(aUserId,out mUserid);
               var mNewsid      = 0;
               int.TryParse(newsId,out mNewsid);

               if (isLogin && String.IsNullOrEmpty(content) == false && mUserid>0 && mNewsid >0){
                    
                    var user = await _context.User.FirstOrDefaultAsync(x => x.Id == mUserid);
                    var news = await _context.News.FirstOrDefaultAsync(x => x.Id == mNewsid);
                    //替换评论中的特殊字符
                    content  = NewsService.ClearHtml(content) ;

                    if (user!=null && news!=null){
                         //插入数据库
                         var news_comment = new News_comment(){

                              Nickname     = user.Nickname,
                              Content      = content,  
                              Userid       = user.Id,
                              Newsid       = news.Id, 
                              Title        = news.Title,
                              State        = 0     //默认不显示

                         };
                         
                         _context.News_comment.Add(news_comment);
                         await _context.SaveChangesAsync();  
                         
                         this.lstComment    = await this.GetCommentList(mNewsid);
                         //把刚刚提交的插入到集合前面，这样当前用户可以看到自己的留言
                         this.lstComment.Insert(0,
                                   new News_commentDTO(){
                                        Nickname   = user.Nickname,
                                        Content    = content,
                                        Createtime = news_comment.Createtime 
                              }
                         );


                    }


               }
             }
             catch(Exception ex){

                  this.ErrorInfo = ex.Message ;

             }
             

             return Page();
        }
    
    }
 }
