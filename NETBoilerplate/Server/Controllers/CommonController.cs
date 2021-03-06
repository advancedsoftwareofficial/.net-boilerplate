﻿using AdvancedSoftware.DataAccess.Entity;
using AdvancedSoftware.DataAccess.Execution;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Routing;

namespace NETBoilerplate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/[controller]")]
    public class CommonController<T> : Controller where T : class, IEntityBase
    {
        private readonly IService<T> _service;

        public CommonController(IService<T> service)
        {
            _service = service;
        }
        [HttpGet]
        [EnableQuery]
        [ODataRoute()]
        public IActionResult Get()
        {
            return Ok(_service.AsDbSet());
        }
        [HttpGet("{key}")]
        [EnableQuery]
        [ODataRoute()]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_service.AsDbSet().FirstOrDefault(y => y.Id == key));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T entity)
        {
            await _service.AddAsync(entity);
            return Created(nameof(Post), entity);
        }
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            _service.Update(entity);
            return Ok(entity);
        }
        [HttpDelete("{key}")]
        public IActionResult Delete([FromRoute] int key)
        {
            _service.Delete(key);
            return Ok();
        }
    }
}
