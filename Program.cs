using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyOrangeCMS_RazorVersion.Data;
using MyOrangeCMS_RazorVersion.Mappings;
using System.Configuration;
using MyOrangeCMS_RazorVersion.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IMapper, Mapper>();

builder.Services.AddScoped<LeftMenuService>();

builder.Services.AddScoped<NewsService>();
builder.Services.AddScoped<News_tagService>();
builder.Services.AddScoped<News_resourceService>();

builder.Services.AddScoped<News_order_listService>();
//News_resourceService
//FileUploadService

builder.Services.AddScoped<FileUploadService>();
builder.Services.AddScoped<FileTemplateService>();
builder.Services.AddScoped<UserService>();



var configuration = new MapperConfiguration(cfg =>
{
    //cfg.
    //cfg.ForAllMaps((obj, cnfg) =>
    //    cnfg.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
});


builder.Services.AddRazorPages( );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//services.AddMvc()
//  .AddRazorPagesOptions(options =>
//  {
//      options.Conventions.AuthorizeFolder("/Account/Manage");
//      options.Conventions.AuthorizePage("/Account/Logout");
//      options.Conventions.AllowAnonymousToPage("/Account/Login");
//  });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)

    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Admin/Managers/Login";
        options.LoginPath = "/Admin/Managers/Login";
    })
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true, //是否验证Issuer
                ValidIssuer = builder.Configuration["Jwt:Issuer"], //发行人Issuer
                ValidateAudience = true, //是否验证Audience
                ValidAudience = builder.Configuration["Jwt:Audience"], //订阅人Audience
                ValidateIssuerSigningKey = true, //是否验证SecurityKey
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])), //SecurityKey
                ValidateLifetime = true, //是否验证失效时间
                ClockSkew = TimeSpan.FromSeconds(30), //过期时间容错值，解决服务器端时间不同步问题（秒）
                RequireExpirationTime = true,
            };
        }
     );

/*
builder.Services.AddDbContext<MyOrangeCMS_RazorVersionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyOrangeCMS_RazorVersionContext") ?? throw new InvalidOperationException("Connection string 'MyOrangeCMS_RazorVersionContext' not found.")));
*/

builder.Services.AddSingleton(new JwtHelper(builder.Configuration));
builder.Services.AddDbContext<MyOrangeCMS_RazorVersionContext>(options =>

options.UseMySql(builder.Configuration.GetConnectionString("MyOrangeCMS_RazorVersionContext_mysql"), new MySqlServerVersion(new Version()), null)
 
    //options.UseMySQL(builder.Configuration.GetConnectionString("MyOrangeCMS_RazorVersionContext_mysql") ?? throw new InvalidOperationException("Connection string 'MyOrangeCMS_RazorVersionContext_mysql' not found."))
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

 

app.UseStaticFiles();

app.UseRouting();

//使用验证
app.UseAuthentication();
app.UseAuthorization();
//app.UseAuthentication();//身分驗證


app.MapRazorPages();
app.MapControllers();

app.Run();
