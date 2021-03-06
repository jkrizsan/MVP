using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVP.API.Helpers;
using MVP.Data;
using MVP.Services;

namespace MVP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IInvoiceDataHelper, InvoiceDataHelper>();
            services.AddScoped<IInvoiceCreatorHelper, InvoiceCreatorHelper>();
            services.AddScoped<IEmailHelper, EmailHelper>();
            services.AddScoped<IOrderHelper, OrderHelper>();

            var options = new DbContextOptionsBuilder<MVPContext>().Options;
            services.AddDbContext<MVPContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Connection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
