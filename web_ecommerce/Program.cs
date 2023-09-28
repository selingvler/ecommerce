using Microsoft.EntityFrameworkCore;
using web_ecommerce;
using web_ecommerce.Business;
using web_ecommerce.Database;
using web_ecommerce.Entities;
using web_ecommerce.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();
builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryBusiness, CategoryBusiness>();
builder.Services.AddScoped<IGenericRepository<UserProduct>, GenericRepository<UserProduct>>();
builder.Services.AddScoped<IUserProductService, UserProductService>();
builder.Services.AddScoped<IUserProductBusiness, UserProductBusiness>();
builder.Services.AddScoped<IGenericRepository<OrderInstance>, GenericRepository<OrderInstance>>();
builder.Services.AddScoped<IOrderInstanceService, OrderInstanceService>();
builder.Services.AddScoped<IOrderInstanceBusiness, OrderInstanceBusiness>();
builder.Services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderBusiness, OrderBusiness>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<WebDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        builder => { builder.MigrationsHistoryTable("__EFMigrationsHistory", "dbo"); }
    );
#if DEBUG
    options.EnableSensitiveDataLogging();
#endif
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}






app.UseHttpsRedirection();

app.UseExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();



app.Run();