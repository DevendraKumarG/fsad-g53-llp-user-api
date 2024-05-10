using Microsoft.EntityFrameworkCore;
using UserService;
using UserService.Middleware;
using UserService.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSettings>(builder.Configuration);

if (builder.Environment.IsDevelopment())
{
    _ = builder.Configuration.AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true);
}
else if (builder.Environment.IsEnvironment("local"))
{
    _ = builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);
}
else
{
    _ = builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
}

builder.Services.AddDbContext<LlpDbContext>(options =>
    options.UseMySql(builder.Configuration["DbConnectionString"],
    new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
