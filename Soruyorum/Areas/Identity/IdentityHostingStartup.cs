using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soruyorum.Data;

[assembly: HostingStartup(typeof(Soruyorum.Areas.Identity.IdentityHostingStartup))]
namespace Soruyorum.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SoruyorumContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("SoruyorumContextConnection")));

               
                services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                })
                        .AddEntityFrameworkStores<SoruyorumContext>();
            });
        }
    }
}