using Discount.Data;
using Microsoft.EntityFrameworkCore;
using Discount.Services;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<DiscountContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DiscountDb"))
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<CityService>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<ProductCityService>();
builder.Services.AddTransient<KeyService>();


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
app.CreateDbIfNotExists();

app.MapControllers();

app.Run();
