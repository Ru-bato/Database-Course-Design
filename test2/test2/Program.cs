using DB_BackendDAL;
using DB_BackendBLL; // ���� BLL �����ռ�
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// ���������ļ������� appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// ��� DAL ���񲢽�����ע��
builder.Services.AddTransient<UserServer>();
builder.Services.AddTransient<AdminServer>();
builder.Services.AddTransient<OrderServer>();
builder.Services.AddTransient<PassengerServer>();  // ��������

// ��� BLL ����
builder.Services.AddTransient<UserManager>();
builder.Services.AddTransient<AdminManager>();
builder.Services.AddTransient<OrderManager>();
builder.Services.AddTransient<PassengerManager>();  // ��������

// ��ӿ���������
builder.Services.AddControllers();

// ���� Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ���� HTTP ����ܵ�
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
