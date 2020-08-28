using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DynamicWebApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DynamicApiController<T> : Controller where T : class, IStorageEntity, new()
    {
        private readonly ILogger _logger;
        private readonly IStorage<T> _storage;

        public DynamicApiController(
            ILogger<DynamicController<T>> logger,
            IStorage<T> storage)
        {
            _logger = logger;
            _storage = storage;
        }

        public List<T> Get()
        {
            return _storage.GetAll().ToList();
        }

        public T Get(Guid id)
        {
            return _storage.GetById(id);
        }

        public IActionResult Save(T entity)
        {
            _storage.AddOrUpdate(entity.Id, entity);
            return Ok();
        }
    }
}
