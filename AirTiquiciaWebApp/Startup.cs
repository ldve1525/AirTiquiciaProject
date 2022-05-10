using AirTiquiciaWebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirTiquiciaWebApp.Services;
using Blazored.LocalStorage;
using Blazored.Modal;

namespace AirTiquiciaWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Identity.Application").AddCookie();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            //services.AddSingleton<AirplaneService>();
            services.AddHttpClient<IAirplaneService, AirplaneService>(client => {client.BaseAddress = new Uri(Configuration["RutaApi"]);});
            services.AddHttpClient<IAerolineService, AerolineService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<IFlightService, FlightService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<IAirportService, AirportService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<IPriceService, PriceService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<ICrewService, CrewService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<IEmployeeService, EmployeeService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<ITicketService, TicketService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<IClassService, ClassService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<ILuggageService, LuggageService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<IPassengerService, PassengerService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });
            services.AddHttpClient<ISeatService, SeatService>(client => { client.BaseAddress = new Uri(Configuration["RutaApi"]); });

            services.AddSession();
            services.AddBlazoredLocalStorage();
            services.AddBlazoredModal();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
