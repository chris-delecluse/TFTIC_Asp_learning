using System.Data;
using Contact.App.Infrastructures.Sessions;
using Contact.Domain.Repositories;
using Contact.Domain.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt =>
    {
        opt.Cookie.Name = "ContactSessionCookie";
        opt.Cookie.HttpOnly = true;
        opt.IdleTimeout = TimeSpan.FromMinutes(10);
    }
);

builder.Services.AddSingleton<IDbConnection>(_ =>
    new SqlConnection(builder.Configuration.GetConnectionString("SqlServer"))
);
builder.Services.AddScoped<IAuthRepository, AuthService>();
builder.Services.AddScoped<IContactRepository, ContactService>();
builder.Services.AddScoped<ISessionManager, SessionManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.Run();
