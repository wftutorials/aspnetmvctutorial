using System;
using AspnetMvcTutorial.Areas.Identity.Data;
using AspnetMvcTutorial.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AspnetMvcTutorial.Areas.Identity.IdentityHostingStartup))]
namespace AspnetMvcTutorial.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AspnetMvcTutorialContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("AspnetMvcTutorialContextConnection")));

                services.AddDefaultIdentity<AspnetMvcTutorialUser>()
                    .AddEntityFrameworkStores<AspnetMvcTutorialContext>();
            });
        }
    }
}