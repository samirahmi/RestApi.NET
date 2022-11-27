using BelajarRESTApi.Application.DefaultServices.ProductService;
using BelajarRESTApi.Application.DefaultServices.ProductService.Dto;
using BelajarRESTApi.Application.Helpers;
using BelajarRESTApi.Application.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelajarRESTApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService; // Business Layer
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet("GetAllProduct")]
        [Produces("application/json")]
        [Authorize] //Diperlukan otorisasi ketika mengakses si API
        public async Task<IActionResult> GetAllProduct([FromQuery] PageInfo pageInfo)
        {
            //// FromBody tidak bisa digunakan untuk method HttpGet
            //// Ada 2 cara untuk bisa mengirim parameter ke HttpGet
            //// 1. Deklarasi variabel 1 per 1
            //// 2. Gunakan FromQuery ( dan tambahkan Default Constructor di Class PageInfo
            try
            {
                var productList = await _productAppService.GetAllProducts(pageInfo);
                if (productList.Data.Count() < 1)
                {
                    //return NotFound();
                    return Requests.Response(this, new ApiStatus(404), null, "Not Found");
                }

                return Requests.Response(this, new ApiStatus(200), productList, "");
            }
            catch(Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message); // not Found
            }  
        }

        [HttpPost("SaveProduct")]
        [Authorize]
        public async Task<IActionResult> SaveProduct([FromBody] CreateProductDto model)
        {
            try
            {
                var (isAdded, isMessage) = await _productAppService.Create(model);
                if (!isAdded)
                {
                    return Requests.Response(this, new ApiStatus(406), isMessage, "Error");
                }

                return Requests.Response(this, new ApiStatus(200), isMessage, "Success");
            }
            catch(Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpGet("GetProductByCode")]
        [Authorize]
        public async Task<IActionResult> GetProductByCode(string code)
        {
            try
            {
                var data = await _productAppService.GetProductByCode(code);
                if (data == null)
                {
                    //return NotFound();
                    return Requests.Response(this, new ApiStatus(404), null, "Not Found");
                }

                return Requests.Response(this, new ApiStatus(200), data, "");
            }
            catch(Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpDelete("DeleteProduct")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var (isDeleted, isMessage) = await _productAppService.Delete(id);
                
                if (!isDeleted)
                {
                    return Requests.Response(this, new ApiStatus(406), isDeleted, "Error");
                }
                else if(isMessage == "Not Found")
                {
                    return Requests.Response(this, new ApiStatus(404), isMessage, "Not Found");
                }

                return Requests.Response(this, new ApiStatus(200), isMessage, "Success");
            }
            catch(Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPatch("UpdateProduct")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto model)
        {
            try
            {
                var (isUpdate, isMessage) = await _productAppService.Update(model);
                if (!isUpdate)
                {
                    return Requests.Response(this, new ApiStatus(406), isUpdate, "Error");
                }

                return Requests.Response(this, new ApiStatus(200), isMessage, "Success");
            }
            catch(Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpGet("SearchProduct")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchProduct(string searchString, [FromQuery] PageInfo pageInfo)
        {
            try
            {
                var data = await _productAppService.SearchProduct(searchString, pageInfo);
                if (data.Data.Count() < 1)
                {
                    //return NotFound();
                    return Requests.Response(this, new ApiStatus(404), null, "Not Found");
                }

                return Requests.Response(this, new ApiStatus(200), data, "");
            }
            catch(Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }    
    }
}
