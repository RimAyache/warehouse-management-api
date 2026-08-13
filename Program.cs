using Microsoft.EntityFrameworkCore;
using warehouse.Api.MappingProfiles;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSingleton<SupplierService>();
builder.Services.AddDbContext<WarehouseDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WarehouseDb")));
builder.Services.AddAutoMapper(typeof(WarehouseProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "warehouse.Api v1"));
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();

app.UseStaticFiles();

app.Run();
