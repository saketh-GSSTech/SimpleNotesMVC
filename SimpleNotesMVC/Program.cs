using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SimpleNotesMVC.Database.Context;
using SimpleNotesMVC.Services.Interfaces;
using SimpleNotesMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SimpleNotesMVCDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), m =>
    {
        m.MigrationsAssembly(typeof(SimpleNotesMVCDbContext).Assembly.FullName);
    });
    opts.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
}, ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IAccountInterface, AccountManager>();

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(30);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SimpleNotesMVCDbContext>();
    dbContext.Database.Migrate(); // Applying pending migrations
}

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=LoginPage}/{id?}");

app.Run();
