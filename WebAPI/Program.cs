using Business.Abstract;
using Business.Concrete;
using DataAccess.Abtract;
using DataAccess.Concrete;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AbcContext>(options =>
{
    options.UseSqlServer("Server=localhost;Initial Catalog=master;TrustServerCertificate=True;User Id=sa;Password=reallyStrongPwd123;", b => b.MigrationsAssembly("WebAPI"));
});

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddScoped<IProductDal, ProductDal>();
builder.Services.AddScoped<IProductService, ProductService>();

ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));

var app = builder.Build();

IWebHostEnvironment environment = builder.Environment;
if (environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(m => m.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();


