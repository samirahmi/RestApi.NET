using BelajarRESTApi.Application.ConfigProfile;
using BelajarRESTApi.Application.DefaultServices.ProductService;
using BelajarRESTApi.Database.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.UnitTest
{
    public class Startup
    {
        public Startup()
        {
            var service = new ServiceCollection();
            service.AddDbContext<SalesContext>(option =>
                option.UseInMemoryDatabase("Host=localhost;Username=postgres;Password=sami;Database=SalesDB; TrustServerCertificate=True;"));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ConfigurationProfile());
            });

            var mapper = config.CreateMapper();

            service.AddSingleton(mapper);
            service.AddTransient<IProductAppService, ProductAppService>();
            ServiceProvider = service.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
