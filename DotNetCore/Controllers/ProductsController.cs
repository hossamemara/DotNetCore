using DotNetCore.Helpers;
using DotNetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
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


        #region GetProducts


        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {

            try
            {
                var data = await _products.GetProducts();
                if (data.Count() > 0)
                {
                    return Ok(new ApiResponse { Data = data, StatusCode = 200, AffectedRows = data.Count(), HttpStatusCodes = "Success" });
                }
                else
                {
                    return NotFound(new ApiResponse { Data = data, StatusCode = 200, AffectedRows = 0, Message = "No Data Found", HttpStatusCodes = "Not Found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { Error = ex.Message, StatusCode = 200, AffectedRows = 0, Message = "No Data Found", HttpStatusCodes = "Not Found" });
            }


        }


        #endregion



    }
}
