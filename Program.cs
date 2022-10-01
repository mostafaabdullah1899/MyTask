
using Task_Rubikans.Models;
using Task_Rubikans.Repository;

using Microsoft.EntityFrameworkCore;
using DevExpress.AspNetCore;
using Microsoft.Extensions.FileProviders;

namespace Final_Project

{
    public class Program
    {
        public static void Main(string[] args)
        {
         
            var builder = WebApplication.CreateBuilder(args);
           
            builder.Services.AddControllersWithViews();
            string ConnectionStrings = builder.Configuration.GetConnectionString("CS");
            // Add services to the container.
            builder.Services.AddMvc().AddRazorRuntimeCompilation();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Entity>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(ConnectionStrings);
            });
            builder.Services.AddDevExpressControls();

            //Registeration
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddScoped<IItemTransactionRepository, ItemTransactionRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //استخدام الفولدر اللازم لانشاء التقرير
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules"
            });

            //Use Devexpress
            app.UseDevExpressControls();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=Index}/{id?}");

            app.Run();
        }
    }
}