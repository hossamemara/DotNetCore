using DotNetCore.ActionFilters;
using DotNetCore.DBContext;
using DotNetCore.Helpers;
using DotNetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProducts _products;
        public ProductsController(ILogger<ProductsController> logger, IProducts products)
        {
            _logger = logger;
            _products = products;
        }


        #region HttpGet

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
                    return Ok(new ApiResponse { Data = data, StatusCode = 200, AffectedRows = data.Count(), Message = "Data Found", HttpStatusCodes = "Success", ExistanceFlag = true });
                }
                else
                {
                    return NotFound(new ApiResponse { StatusCode = 404, AffectedRows = 0, Message = "No Data Found", HttpStatusCodes = "Not Found", ExistanceFlag = false });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());
                return BadRequest(new ApiResponse { Error = ex.Message.ToString(), StatusCode = 400, HttpStatusCodes = "Bad Request" });
            }


        }


        #endregion


        #region Get GetProducts By Filter


        [HttpGet("GetProductsByFilter/{id}")]

        //  Middleware & action filter   https://chatgpt.com/share/e/68c53a88-bc5c-8001-9be6-80686b688b98 
        [SensitiveLogActivity]
        public async Task<IActionResult> GetProductsByFilter(int id)
        {
            _logger.LogInformation("GetProductsByFilter");
            try
            {
                var data = await _products.GetProductsByFilter(id);
                if (data is not null)
                {
                    return Ok(new ApiResponse { Data = data, StatusCode = 200, AffectedRows = 1, Message = "Data Found", HttpStatusCodes = "Success", ExistanceFlag = true });
                }
                else
                {
                    return NotFound(new ApiResponse { StatusCode = 404, AffectedRows = 0, Message = "No Data Found", HttpStatusCodes = "Not Found", ExistanceFlag = false });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());
                return BadRequest(new ApiResponse { Error = ex.Message.ToString(), StatusCode = 400, HttpStatusCodes = "Bad Request" });
            }


        }


        #endregion

        #endregion


        #region HttpPost

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

        #endregion


        #region HttpPut

        #region Update Product

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {

            try
            {

                var data = await _products.UpdateProduct(product);
                if (data is not null)
                {
                    return Ok(new ApiResponse { Data = data, StatusCode = 200, AffectedRows = 1, HttpStatusCodes = "Success", ExistanceFlag = true, Message = "Updated Successfully" });
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


        #endregion


        #region HttpDelete

        #region Delete Product

        [HttpDelete("DeleteProduct{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            try
            {

                var data = await _products.DeleteProduct(id);
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


        #endregion

    }
}
