using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.UnitTest
{
    public class MockProductAppServiceTestsFixture
    {
        [Fact]
        public async Task GetAll()
        {
            var mockProductAppServiceTest = new MockProductAppServiceTests();

            var result = mockProductAppServiceTest.GetAllProducts();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create()
        {
            var mockProductAppServiceTest = new MockProductAppServiceTests();

            var result = mockProductAppServiceTest.CreateProducts();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete()
        {
            var mockProductAppServiceTest = new MockProductAppServiceTests();

            var result = mockProductAppServiceTest.DeleteProducts();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Update()
        {
            var mockProductAppServiceTest = new MockProductAppServiceTests();

            var result = mockProductAppServiceTest.UpdateProducts();
            Assert.NotNull(result);
        }
    }
}
