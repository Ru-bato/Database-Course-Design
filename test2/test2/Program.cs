using DB_BackendDAL;
using DB_BackendBLL; // 引入 BLL 命名空间
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 加载配置文件，包括 appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// 添加 DAL 服务并将配置注入
builder.Services.AddTransient<UserServer>();
builder.Services.AddTransient<AdminServer>();
builder.Services.AddTransient<OrderServer>();
builder.Services.AddTransient<PassengerServer>();  // 新增服务

// 添加 BLL 服务
builder.Services.AddTransient<UserManager>();
builder.Services.AddTransient<AdminManager>();
builder.Services.AddTransient<OrderManager>();
builder.Services.AddTransient<PassengerManager>();  // 新增服务

// 添加控制器服务
builder.Services.AddControllers();

// 配置 Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 配置 HTTP 请求管道
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
