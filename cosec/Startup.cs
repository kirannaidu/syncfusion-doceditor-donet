using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.ResponseCompression;

using System.Net.Http;
/* using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using Syncfusion.EJ2.DocumentEditor;
using WDocument = Syncfusion.DocIO.DLS.WordDocument;
using WFormatType = Syncfusion.DocIO.FormatType;
using Syncfusion.EJ2.SpellChecker;
using EJ2APIServices; */

namespace cosec
{
    public static class PolicyNames
    {
        public const string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";
    }

    public class Startup
    {
        // Amazon.Util.ProfileManager.RegisterProfile("sync_development","", "");

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // readonly string MyAllowSpecificOrigins = "MyPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS services
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost4200",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            // Add framework services.
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors("AllowLocalhost4200");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

