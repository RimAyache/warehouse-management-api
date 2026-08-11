using Microsoft.EntityFrameworkCore;
using warehouse.Api.Models.DbFirst;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSingleton<SupplierService>();
builder.Services.AddDbContext<WarehouseDbFirstContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WarehouseDbFirst")));

    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "warehouse.Api v1"));
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();


app.Run();
