using BelajarRESTApi.Application.DefaultServices.ProductService;
using BelajarRESTApi.Application.DefaultServices.ProductService.Dto;
using BelajarRESTApi.Application.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.UnitTest
{
    public class MockProductAppServiceTests : Mock<IProductAppService>
    {
        public MockProductAppServiceTests GetAllProducts()
        {
            PageInfo pageInfo = new PageInfo()
            {
                Page = 1,
                PageSize = 10
            };

            PagedResult<ProductListDto> pagedResult = new PagedResult<ProductListDto>();
            Setup(x => x.GetAllProducts(pageInfo))
                .ReturnsAsync(pagedResult);

            return this;
        }

        public MockProductAppServiceTests CreateProducts()
        {
            CreateProductDto create = new CreateProductDto()
            {
                ProductCode = "PD-005",
                ProductName = "FROM UNIT TESTING In MEMORY",
                ProductPrice = 10000,
                ProductQty = 100,
                SupplierId = 1
            };

            Setup(x => x.Create(create));

            return this;
        }

        public MockProductAppServiceTests DeleteProducts()
        {
            int id = 1;

            Setup(x => x.Delete(id));
            return this;
        }

        public MockProductAppServiceTests UpdateProducts()
        {
            UpdateProductDto update = new UpdateProductDto()
            {
                ProductId = 1,
                ProductCode = "PD-001",
                ProductName = "FROM UNIT TESTING In MEMORY",
                ProductPrice = 10000,
                ProductQty = 100,
                SupplierId = 1
            };

            Setup (x => x.Update(update));
            return this;
        }
    }
}
