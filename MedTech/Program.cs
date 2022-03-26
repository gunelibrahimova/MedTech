using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<HealthyServices>();
builder.Services.AddScoped<ProfessionServices>();
builder.Services.AddScoped<QualityServices>();
builder.Services.AddScoped<ProtectServices>();
builder.Services.AddScoped<PatientServices>();
builder.Services.AddScoped<AboutServices>();
builder.Services.AddScoped<NewsServices>();
builder.Services.AddScoped<AppServices>();
builder.Services.AddScoped<PhotoServices>();
builder.Services.AddScoped<DetailServices>();
builder.Services.AddScoped<SkilServices>();
builder.Services.AddScoped<SubscribeServices>();
builder.Services.AddScoped<BookServices>();


var connectingString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MedTechDbContext>
    (options => options.UseSqlServer(connectingString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
