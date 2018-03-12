using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchoolStore.Models;



namespace SchoolStore
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

            services.AddMvc();
            services.AddAntiforgery();
            services.AddSession();

            services.Configure<Models.ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddOptions();



            //for Identity Framework stuff




            //Old HArdcoded way to handle Identity Framework EF
            services.AddDbContext<JimTestContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly(this.GetType().Assembly.FullName)));
            //opt.UseInMemoryDatabase("Identities"));
            //opt.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = JimTest; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False",
            //sqlOptions => sqlOptions.MigrationsAssembly(this.GetType().Assembly.FullName))
            //);


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<JimTestContext>()
                .AddDefaultTokenProviders();


            //add smarty streets stuff here and put tokens in secrets file
            services.AddTransient<SmartyStreets.USStreetApi.Client>((x) =>
            {
                var client = new SmartyStreets.ClientBuilder(
                    Configuration["smartystreets.authid"],
                    Configuration["smartystreets.authtoken"])

                        .BuildUsStreetApiClient();

                return client;
            });

            services.AddTransient<SendGrid.SendGridClient>((x) =>
            {
                return new SendGrid.SendGridClient(Configuration["sendgrid"]);
            });

            services.AddTransient<Braintree.BraintreeGateway>((x) =>
            {
                return new Braintree.BraintreeGateway(
                    Configuration["braintree.environment"],
                    Configuration["braintree.merchantid"],
                    Configuration["braintree.publickey"],
                    Configuration["braintree.privatekey"]
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, JimTestContext context, SendGrid.SendGridClient sendGridClient)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }



            

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //put our intitialization logic
           DbInitializer.Initialize(context);



        }
    }
}
