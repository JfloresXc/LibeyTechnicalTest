using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.DocumentType
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeAggregate _aggregate;
        public DocumentTypeController(IDocumentTypeAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            var row = _aggregate.ListAll();
            return Ok(row);
        }
    }
}