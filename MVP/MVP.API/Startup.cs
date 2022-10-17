using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MVP.Data;
using MVP.Services;
using MVP.Services.Factories;
using MVP.Services.Repositories;

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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailFactory, EmailFactory>();
            services.AddScoped<IMessageFactory, InvoiceMessageFactory>();
            services.AddScoped<IInvoiceBuilderServiceFactory, InvoiceBuilderServiceFactory>();

            var options = new DbContextOptionsBuilder<MVPContext>().Options;
            services.AddDbContext<MVPContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Connection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MVP", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson();
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MVP API V1");
            });
        }
    }
}
