using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using PABP_Second_Project_API.Filters;
using PABP_Second_Project_API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ApiExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => 
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    x.IncludeXmlComments(xmlPath, true);
});

builder.Services.AddDbContext<NorthwindContext>(optionsBuilder => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Northwind;Trusted_Connection=True;"));
builder.Services.AddCors(options => options.AddPolicy("CORSPOLICY", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));


builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ISuppliersRepository, SupplierRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("CORSPOLICY");

app.MapControllers();

app.Run();
