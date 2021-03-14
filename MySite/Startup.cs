using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Поддержка контроллеров и представлений (MVC)
            services.AddControllersWithViews()
                //совместимость с asp.net core 3.0
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
            //services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //!! Порядок регистрации middlware очень важен

            //В процессе разработки нам важно видеть подробную информацию об ошибках
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            //Поддержка стациных файлов (css, js и т.д.)
            app.UseStaticFiles();

            //Регистрация нужных маршрутов(ендпоинты)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); // id? - ? означает что он не обязателен
            });

            /*else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }*/

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseAuthorization();

        }
    }
}
