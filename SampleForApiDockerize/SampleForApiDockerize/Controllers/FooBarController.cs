using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleForApiDockerize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooBarController : ControllerBase
    {
        public FooBarController()
        {

        }

        [HttpGet]
        [Route("Read")]
        public async Task<IActionResult> Read()
        {
            return await Task.FromResult(Ok(1));
        }
    }
}