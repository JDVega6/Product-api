using ApiProducts.Data;
using ApiProducts.Data.Mapper;
using ApiProducts.Data.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductContextDb>(options => options.UseMySQL(mysqlConnection));

builder.Services.AddControllers();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

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

app.Run();
