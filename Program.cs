using HotWalletsTrialApp.Models;
using HotWalletsTrialApp.Models.Abstract;
using HotWalletsTrialApp.Models.Concrete;
using HotWalletsTrialApp.Models.DBContext.EntityFramework;
using HotWalletsTrialApp.Models.Repositories.Abstract;
using HotWalletsTrialApp.Models.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    public static Account CurrentAccount = new Account();
    public static string ConnectionString = string.Empty;

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        ConnectionString = builder.Configuration.GetConnectionString("HotWalletsDbString");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<EfContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}