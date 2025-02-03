using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Province
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinceController : Controller
    {
        private readonly IProvinceAggregate _aggregate;
        public ProvinceController(IProvinceAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<ProvinceResponse> rows = _aggregate.ListAll();
                var response = new ApiResponse<List<ProvinceResponse>>(rows, "Data retrieved successfully", true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data" + ex.Message);
            }
        }
    }
}