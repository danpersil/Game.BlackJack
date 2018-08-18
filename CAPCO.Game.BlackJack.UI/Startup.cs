using CAPCO.Game.Configuration.Injection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CAPCO.Game.BlackJack.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public string SystemVersion { get; set; }
        public string SystemName { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            SystemVersion = "Versão 0.0.1";

            SystemName = "CAPCO - Game - BlackJack";

            services.AddSwaggerGen(c => c.SwaggerDoc(SystemVersion, new Info { Title = SystemName, Version = SystemVersion }));

            services.AddMemoryCache();

            services.AddMvc();

            DependencyInjection _dependency = new DependencyInjection();
            _dependency.Injection(services);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{SystemVersion}/swagger.json", SystemName));
        }
    }
}
