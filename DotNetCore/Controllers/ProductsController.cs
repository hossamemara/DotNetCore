using DotNetCore.DBContext;
using DotNetCore.Helpers;
using DotNetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetCore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProducts _products;
        public ProductsController(ILogger<WeatherForecastController> logger, IProducts products)
        {
            _logger = logger;
            _products = products;
        }


        #region Get Products


        
        
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation("GetProducts");
            try
            {
                var data = await _products.GetProducts();
                if (data.Count() > 0)
                {
                    return Ok(new ApiResponse { Data = data, StatusCode = 200, AffectedRows = data.Count(), Message = "Data Found",HttpStatusCodes = "Success", ExistanceFlag=true });
                }
                else
                {
                    return NotFound(new ApiResponse { Data = data, StatusCode = 404, AffectedRows = 0, Message = "No Data Found", HttpStatusCodes = "Not Found", ExistanceFlag = false });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());
                return BadRequest(new ApiResponse { Error = ex.Message.ToString(), StatusCode = 400, HttpStatusCodes = "Bad Request" });
            }


        }


        #endregion
        
        #region Add Product

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {

            try
            {
                var data = await _products.AddProduct(product);
                return Ok(new ApiResponse { Data = data, StatusCode = 200, AffectedRows = 1, HttpStatusCodes = "Success", Message = "Added Successfully", ExistanceFlag = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { Error = ex.Message.ToString(), StatusCode = 400, HttpStatusCodes = "BadRequest" });
            }


        }


        #endregion


        #region Update Product

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {

            try
            {

                var data = await _products.UpdateProduct(product);
                if (data is not null)
                {
                    return Ok(new ApiResponse { Data = data, StatusCode = 200, AffectedRows = 1, HttpStatusCodes = "Success", ExistanceFlag = true, Message="Updated Successfully" });
                }
                else
                {
                    return NotFound(new ApiResponse { StatusCode = 404, AffectedRows = 0, Message = "No Data Found", HttpStatusCodes = "Not Found", ExistanceFlag = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { Error = ex.Message.ToString(), StatusCode = 400, HttpStatusCodes = "Bad Request" });
            }


        }


        #endregion


        #region Delete Product

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Product product)
        {

            try
            {

                var data = await _products.DeleteProduct(product);
                if (data is not null)
                {
                    return Ok(new ApiResponse { Data = data, StatusCode = 200, AffectedRows = 1, HttpStatusCodes = "Success", ExistanceFlag = true, Message = "Deleted Successfully" });
                }
                else
                {
                    return NotFound(new ApiResponse { StatusCode = 404, AffectedRows = 0, Message = "No Data Found", HttpStatusCodes = "Not Found", ExistanceFlag = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { Error = ex.Message.ToString(), StatusCode = 400, HttpStatusCodes = "Bad Request" });
            }


        }


        #endregion

    }
}
