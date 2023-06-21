using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using IDalAuthRepository = Contact.DAL.Repositories.IAuthRepository;
using DalAuthService = Contact.DAL.Services.AuthService;
using IBllAuthRepository = Contact.BLL.Repositories.IAuthRepository;
using BllAuthService = Contact.BLL.Services.AuthService;
using IDalContactRepository = Contact.DAL.Repositories.IContactRepository;
using DalContactService = Contact.DAL.Services.ContactService;
using IBllContactRepository = Contact.BLL.Repositories.IContactRepository;
using BllContactService = Contact.BLL.Services.ContactService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDbConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<IDalAuthRepository, DalAuthService>();
builder.Services.AddScoped<IBllAuthRepository, BllAuthService>();
builder.Services.AddScoped<IDalContactRepository, DalContactService>();
builder.Services.AddScoped<IBllContactRepository, BllContactService>();

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

app.MapControllerRoute(name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
