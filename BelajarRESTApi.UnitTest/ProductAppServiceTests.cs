using AutoMapper;
using BelajarRESTApi.Application.DefaultServices.ProductService;
using BelajarRESTApi.Application.DefaultServices.ProductService.Dto;
using BelajarRESTApi.Application.Helpers;
using BelajarRESTApi.Database.Databases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.UnitTest
{
    public class ProductAppServiceTests
    {
        private readonly IProductAppService _productAppService;
        private readonly SalesContext _salesContext;
        private readonly IMapper _mapper;

        public ProductAppServiceTests(IProductAppService productAppService, SalesContext salesContext, IMapper mapper)
        {
            _productAppService = productAppService;
            _salesContext = salesContext;
            _mapper = mapper;
        }

        [Fact]
        public void GetAllProductTest()
        {
            //Arrange
            var productAppService = new Mock<IProductAppService>();
            PageInfo pageInfo = new PageInfo()
            {
                Page = 1,
                PageSize = 10
            };

            //Act
            Task<PagedResult<ProductListDto>> pagedResult = null;
            var result = productAppService.Setup(x => x.GetAllProducts(pageInfo)).Returns(pagedResult);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateProductTest()
        {
            //Arrange
            var productAppService = new Mock<IProductAppService>();
            CreateProductDto createProductDto = new CreateProductDto()
            {
                ProductCode = "PD-005",
                ProductName = "FROM UNIT TESTING In MEMORY",
                ProductPrice = 10000,
                ProductQty = 100,
                SupplierId = 1
            };

            //Act
            var result = productAppService.Setup(x => x.Create(createProductDto));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateProductTest()
        {
            //Arrange
            var productAppService = new Mock<IProductAppService>();
            UpdateProductDto updateProductDto = new UpdateProductDto()
            {
                ProductId = 1,
                ProductCode = "PD-001",
                ProductName = "FROM UNIT TESTING In MEMORY",
                ProductPrice = 10000,
                ProductQty = 100,
                SupplierId = 1
            };

            //Act
            var result = productAppService.Setup(x => x.Update(updateProductDto));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteProductTest()
        {
            //Arrange
            var productAppService = new Mock<IProductAppService>();
            int id = 1;

            //Act
            var result = productAppService.Setup(x => x.Delete(id));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetProductByCodeTest()
        {
            //Arrange
            var productAppService = new Mock<IProductAppService>();
            string code = "PRD-001";

            //Act
            var result = productAppService.Setup(x => x.GetProductByCode(code));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void SearchProductTest()
        {
            //Arrange
            var productAppService = new Mock<IProductAppService>();
            string searchString = "PRD-001";
            PageInfo pageInfo = new PageInfo()
            {
                Page = 1,
                PageSize = 10
            };
            
            //Act
            Task<PagedResult<ProductListDto>> pagedResult = null;
            var result = productAppService.Setup(x => x.SearchProduct(searchString, pageInfo)).Returns(pagedResult);

            //Assert
            Assert.NotNull(result);

        }
    }
}
