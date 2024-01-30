using E_Commerce.Data.DbInitializer;
using E_Commerce.Data.Repository;
using E_Commerce.Model.AutoMapper;
using E_Commerce.Services;
using E_Commerce_CORE_MVC.MyDbContext;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


builder.Services.AddMvc().AddNewtonsoftJson();


builder.Services.AddDbContext<OnlineShopDbContext>(options =>
{
	options.UseSqlServer(
		builder.Configuration["ConnectionStrings:OnlineShopConnectionStringApi"]
		);
});


//Start Auto Mapper Configurations
builder.Services.AddAutoMapper(typeof(MappingProfile));





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

OnlineShopDbInitializer.Seed(app);

app.Run();
