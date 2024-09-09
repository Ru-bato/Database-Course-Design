using DB_Backend.DB_BackendDAL;
using DB_Backend.DB_BackendBLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddTransient<UserServer>();
builder.Services.AddTransient<AdminServer>();
builder.Services.AddTransient<OrderServer>();
builder.Services.AddTransient<PassengerServer>();

builder.Services.AddTransient<UserManager>();
builder.Services.AddTransient<AdminManager>();
builder.Services.AddTransient<OrderManager>();
builder.Services.AddTransient<PassengerManager>();

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped<UserServer>();

builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<Glue.Controllers.FileHelper>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyTicketDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDbConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

//app.UseHttpsRedirection();
app.UseCors("AllowAll"); // 使用 CORS 策略
app.UseStaticFiles(); // 允许前端访问后端服务器的静态资源

app.UseAuthorization();

app.MapControllers();

app.Run();
