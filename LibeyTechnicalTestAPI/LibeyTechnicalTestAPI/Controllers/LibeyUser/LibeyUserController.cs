using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<LibeyUserResponse> rows = _aggregate.ListAll();
                var response = new ApiResponse<List<LibeyUserResponse>>(rows, "Data retrieved successfully", true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data" + ex.Message);
            }
        }

        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            try
            {
                var row = _aggregate.FindResponse(documentNumber);
                var response = new ApiResponse<object>(row, "Data retrieved successfully", true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data" + ex.Message);
            }

        }

        [HttpPost]       
        public IActionResult Create(UserUpdateorCreateCommand command)
        {
            try
            {
                _aggregate.Create(command);
                var response = new ApiResponse<object>(null, "Data added successfully", true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("{documentNumber}")]
        public IActionResult Delete(string documentNumber)
        {
            try
            {
                _aggregate.Delete(documentNumber);
                var response = new ApiResponse<object>(null, "Data deleted successfully", true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data" + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(UserUpdateorCreateCommand command)
        {
            try
            {
                _aggregate.Update(command);
                var response = new ApiResponse<object>(null, "Data updated successfully", true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data" + ex.Message);
            }
        }

        [HttpGet]
        [Route("{documentNumber}/{isActived}")]
        public IActionResult ToggleActive(string documentNumber, bool isActived)
        {
            try
            {
                _aggregate.ToggleActive(documentNumber, isActived);
                var response = new ApiResponse<object>(null, "State active toggled successfully", true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving data" + ex.Message);
            }
        }
    }
}