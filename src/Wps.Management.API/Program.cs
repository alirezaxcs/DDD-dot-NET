using Microsoft.EntityFrameworkCore;
using Wps.Management.API.Infrastructor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ManagementDbcontext>(optiosn => {
    optiosn.UseSqlite("Data Source=WPSManagement.db");
});
var app = builder.Build();
app.EnsureDatabaseCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "openapi/v1.json";
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
