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

 namespace MyOrangeCMS_RazorVersion.DTO
 {
      public class JsonResultDTO
     {
        public JsonResultDTO()
        {
             
        }
        public JsonResultDTO(string msg,int result,object data)
        {
            this.Msg = msg;
            this.Result = result ;
            this.Data = data;
             
        }

        public string Msg{get;set;}
        public int    Result{get;set;}

        public object Data{get;set;}
           
      }
 }
