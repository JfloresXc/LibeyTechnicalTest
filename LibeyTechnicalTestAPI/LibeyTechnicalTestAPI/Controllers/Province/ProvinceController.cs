﻿using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
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
            var row = _aggregate.ListAll();
            return Ok(row);
        }
    }
}