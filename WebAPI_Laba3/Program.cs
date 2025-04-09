using Microsoft.EntityFrameworkCore;
using WebAPI_Laba3;

var builder = WebApplication.CreateBuilder(args);

SQLitePCL.Batteries.Init();

builder.Services.AddDbContext<ApplicationContext>(
    options =>
    {
        var config = builder.Configuration;
        options.UseSqlite(config.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddControllers(); // Добавляем контроллеры

// Логирование для отладки
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Добавляем swagger
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

app.Run();
