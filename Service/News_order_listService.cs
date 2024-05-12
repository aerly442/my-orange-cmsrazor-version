using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.DTO;
using MyOrangeCMS_RazorVersion.Models;

namespace MyOrangeCMS_RazorVersion.Service
{


    public class News_order_listService
    {
        private readonly MyOrangeCMS_RazorVersionContext _context;

        public News_order_listService(MyOrangeCMS_RazorVersionContext context)
        {

            _context = context;
        }
        
        public News_order_list AddOrder(int newsId,int userId){
           
           var user = this._context.User.FirstOrDefault(x=>x.Id==userId);
           if (user == null){
               return null ;
           }

           var news = this._context.News.FirstOrDefault(x=>x.Id==newsId);
           if (news == null){
               return null ;
           }
           var tradeNo = this.GetTradeNo();
           var data = new News_order_list(){
                            //Title       = news.Title,
                            //Nickname    = user.Nickname,                                       
                            Email       = user.Email,                                                                                                                          
                            Pay_state   = 0,       
                            Pay_price   = news.Price,                              
                            Trade_no    = tradeNo,   
                            Newsid      = news.Id,           
                            Userid      = user.Id,
                            Pay_time    = null
           };

            _context.News_order_list.Add(data);
            _context.SaveChanges();

           var order = this._context.News_order_list.FirstOrDefault(x=>x.Id==data.Id);

           return order;


        }

        private string GetTradeNo(){

            string trade_no = DateTime.Now.ToString("yyyyMMddHHssffff");
            return trade_no;


        }

        public IQueryable<News_order_listDTO> GetQuery()
        {
              
               var query =  from order in _context.News_order_list
                 join news in _context.News on order.Newsid equals news.Id
                 join user in _context.User on order.Userid equals user.Id
                 select new News_order_listDTO {
                                  
                            Id          = order.Id,    
                            Title       = news.Title,
                            Nickname    = user.Nickname,                                       
                            Email       = user.Email,                                       
                            Note        = order.Note,                                        
                            Updatetime  = order.Updatetime,       
                            Pay_state   = order.Pay_state,       
                            Pay_price   = order.Pay_price,       
                            Pay_time    = order.Pay_time,       
                            Trade_no    = order.Trade_no,   
                            Newsid      = order.Newsid,           
                            Userid      = order.Userid
                                                  

                 } ; 
                 return query;
              
        }
    }
}