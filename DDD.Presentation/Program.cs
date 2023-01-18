using DDD.Data.Context;
using DDD.Data.Repositories;
using DDD.Domain.Interfaces.Repositories;
using DDD.Presentation.AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddDbContextPool<ContextSettings>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

var config = new AutoMapper.MapperConfiguration(config =>
{
    config.AddProfile<ModelToDomainMappingProfile>();
    config.AddProfile<DomainToModelMappingProfile>();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
