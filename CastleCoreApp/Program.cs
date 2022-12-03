using CastleCoreApp.Extensions;
using CastleCoreApp.Interceptors;
using CastleCoreApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<InterceptorWraper>();
builder.Services.AddInterceptoreScoped<ICustomerService, CustomerService>();

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

app.Run();
