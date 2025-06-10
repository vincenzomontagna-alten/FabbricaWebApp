using System.Net.Http;
using FabbricaWebApp.Data;
using FabbricaWebApp.Data.Repositories;
using FabbricaWebApp.DelegatingHandlerNamespace;
using FabbricaWebApp.Middleware;
using FabbricaWebApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
//  Registra il DbContext nella dependency injection
builder.Services.AddDbContext<FabbricaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FabbricaDb")));
builder.Services.AddTransient<IProdottoTerminatoRepositoryInterface, ProdottoTerminatoRepository>();

//builder.Services.AddHttpClient();
builder.Services.AddTransient<DelegatingHandlerTest>();
builder.Services.AddHttpClient<HttpClientTest>()
    .AddHttpMessageHandler<DelegatingHandlerTest>();

var configuration = builder.Configuration;
builder.Services.AddSingleton(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
