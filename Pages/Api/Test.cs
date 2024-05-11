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

 using Microsoft.AspNetCore.Mvc;

 namespace MyOrangeCMS_RazorVersion.Pages.Api
 {
    [ApiController] 
    public class TestController : ControllerBase
    {
        public TestController()
        {
            //_logger = logger;
        }
    
        [HttpGet]
        [Route("/Api/t1")]
        public async Task<ActionResult<string>> t1(long id)
        {
            return "abc";
        }
        
    }
 
 }
