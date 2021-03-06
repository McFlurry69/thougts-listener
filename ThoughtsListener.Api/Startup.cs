using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThoughtsListener.Data;

namespace ThoughtsListener.Api
{
    public class Startup
    {
        private const string CorsPolicy = "All";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Db"));
            services.AddControllers();
            services.AddCors(options =>
                options.AddPolicy(CorsPolicy, builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(CorsPolicy);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}