using Autofac;
using Autofac.Extensions.DependencyInjection;
using RabitMqProductAPI.AutofacConfig;
using RabitMqProductAPI.Data;
using RabitMqProductAPI.Helper;
using RabitMqProductAPI.RabitMQ;
using RabitMqProductAPI.ServiceExtension;
using RabitMqProductAPI.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// 1、配置host与容器
builder.Host
.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>(builder =>
{
   // builder.RegisterModule(new AutofacModuleRegister());
    //builder.RegisterModule<AutofacPropertityModuleReg>();
})
.ConfigureLogging((hostingContext, builder) =>
{
    builder.AddFilter("System", LogLevel.Error);
    builder.AddFilter("Microsoft", LogLevel.Error);
    builder.SetMinimumLevel(LogLevel.Error);
    //builder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "Log4net.config"));
});


//注册AppSettings
builder.Services.AddSingleton(new AppSettings(builder.Configuration));

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<DbContextClass>();
//builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();
//注册rabbitmq相关配置
builder.Services.AddRabbitMQSetup();
builder.Services.AddEventBusSetup();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//注册Product事件源与事件处理
app.ConfigureEventBus();

app.Run();
