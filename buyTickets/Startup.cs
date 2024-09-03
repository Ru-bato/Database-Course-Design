using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using buyTickets.BackendBLL; 
using buyTickets.BackendModel;
using Microsoft.EntityFrameworkCore;
using buyTickets.BackendDAL;

namespace buyTickets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method is called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // 添加 CORS 配置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            // 配置 Oracle 数据库上下文
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseOracle(Configuration.GetConnectionString("DefaultConnection")));

            // 注册业务逻辑层服务
            services.AddScoped<ITicketService, TicketService>();
        }

        // This method is called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAll"); // 启用 CORS 策略

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // 映射控制器
            });
        }
    }
}
