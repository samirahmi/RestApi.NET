using BelajarRESTApi.Application.ConfigProfile;
using BelajarRESTApi.Application.DefaultServices.ProductService;
using BelajarRESTApi.Application.DefaultServices.ProductService.Dto;
using BelajarRESTApi.Application.Helpers;
using BelajarRESTApi.Database.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.UnitTest
{
    //public class ServiceFixture
    //{
    //    // UseInMemoryDatabase ---> menggunakan schema aslinya tanpa harus crud ke db
    //    public ServiceFixture()
    //    {
    //        var serviceCollection = new ServiceCollection();

    //        serviceCollection.AddDbContext<SalesContext>(option =>
    //            //option.UseNpgsql("Host=localhost;Username=postgres;Password=sami;Database=SalesDB; TrustServerCertificate=True;"));
    //            option.UseInMemoryDatabase("Host=localhost;Username=postgres;Password=sami;Database=SalesDB; TrustServerCertificate=True;"));


    //        var config = new AutoMapper.MapperConfiguration(cfg =>
    //        {
    //            cfg.AddProfile(new ConfigurationProfile());
    //        });

    //        var mapper = config.CreateMapper();
    //        serviceCollection.AddSingleton(mapper);
    //        serviceCollection.AddTransient<IProductAppService, ProductAppService>();
    //        serviceProvider = serviceCollection.BuildServiceProvider();
    //    }

    //    public ServiceProvider serviceProvider { get; set; }
    //}

    public class ProductAppServiceTestsTanpaMock : IClassFixture<Startup>
    {
        private ServiceProvider _serviceProvider;

        public ProductAppServiceTestsTanpaMock(Startup fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void CreateProduct()
        {
            var service = _serviceProvider.GetService<IProductAppService>();

            //Arrange
            CreateProductDto createProductDto = new CreateProductDto()
            {
                ProductCode = "PD-001",
                ProductName = "FROM UNIT TESTING In MEMORY",
                ProductPrice = 10000,
                ProductQty = 100,
                SupplierId = 1
            };

            //Act
            var result = service.Create(createProductDto);

            //Assert
            Assert.True(result.Result.Item1);
        }

        [Fact]
        public async void UpdateProductTest()
        {
            var service = _serviceProvider.GetService<IProductAppService>();

            //Arrange
            UpdateProductDto update = new UpdateProductDto()
            {
                ProductId = 11,
                ProductCode = "PD-002",
                ProductName = "FROM UNIT TESTING",
                ProductPrice = 10000,
                ProductQty = 100,
                SupplierId = 1
            };

            //Act
            var result = await service.Update(update);

            //Assert
            Assert.True(result.Item1);
        }

        [Fact]
        public async void GetAllProductTest()
        {
            var service = _serviceProvider.GetService<IProductAppService>();

            //Arrange
            PageInfo pageInfo = new PageInfo()
            {
                Page = 1,
                PageSize = 5
            };

            //Act
            var result = await service.GetAllProducts(pageInfo);

            //Assert
            //Assert.NotEmpty(result.Data); //check jika collection itu null
            Assert.Empty(result.Data); //
            Assert.NotNull(result);
        }

        [Fact]
        public async void DeleteProduct()
        {
            var service = _serviceProvider.GetService<IProductAppService>();

            //Arrange
            int id = 11;

            //Act
            var result = await service.Delete(id);

            //Assert
            Assert.True(result.Item1);
        }

        [Fact]
        public void CreateProduct_FailedTest()
        {
            var service = _serviceProvider.GetService<IProductAppService>();

            //Arrange
            CreateProductDto createProductDto = new CreateProductDto()
            {
                ProductCode = "PD-001",
                ProductName = "FROM UNIT TESTING",
                ProductPrice = 10000,
                ProductQty = 100,
                SupplierId = 1
            };

            //Act

            //Assert
            //Assert.Throws ==> syn
            Assert.ThrowsAsync<DbException>(() => service.Create(createProductDto));

        }
    }
}
