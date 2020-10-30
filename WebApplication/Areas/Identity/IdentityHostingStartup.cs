using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Areas.Identity.Data;
using WebApplication.Data;

[assembly: HostingStartup(typeof(WebApplication.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            /*builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext<Uzytkownik>>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddDefaultIdentity<Uzytkownik>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext<Uzytkownik>>();
            });*/
        }
    }
}