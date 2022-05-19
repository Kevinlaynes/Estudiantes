using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PepitoSchool.AppCore.Interface;
using PepitoSchool.AppCore.Service;
using PepitoSchool.Domain.Interfaces;
using PepitoSchool.Domain.PepitoSchoolEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepitoSchool.Presentation
{
    static class Program
    {
       
        public static IConfiguration Configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables().Build();

            //var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            //{
            //    services.AddDbContext<DepreciationDBContext>(options =>
            //    {
            //        options.UseSqlServer(Configuration.GetConnectionString("Default"));
            //    });
            //});

            //var host = builder.Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            services.AddDbContext<PepitoSchoolContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IPepitoSchoolContext,PepitoSchoolContext>();
            services.AddScoped<IEstudiantesService, EstudianreServuce>();
            services.AddScoped<Form1>();
            services.AddScoped<Form1>();

            using (var serviceScope = services.BuildServiceProvider())
            {
                var main = serviceScope.GetRequiredService<Form1>();
                Application.Run(main);
            }

        }
    }
}
