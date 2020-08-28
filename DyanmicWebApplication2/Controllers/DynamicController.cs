using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DynamicWebApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class DynamicController<T> : Controller where T : class, IStorageEntity, new()
    {
        private readonly ILogger _logger;
        private readonly IStorage<T> _storage;

        public DynamicController(
            ILogger<DynamicController<T>> logger,
            IStorage<T> storage)
        {
            _logger = logger;
            _storage = storage;
        }

        public IActionResult Index()
        {
            var all = _storage.GetAll().ToList();
            return View("~/Views/Dynamic/Index.cshtml", all);
        }

        public IActionResult Add()
        {
            var obj = new T();
            obj.Id = Guid.NewGuid();
            return View("~/Views/Dynamic/Edit.cshtml", obj);
        }

        public IActionResult Edit(Guid id)
        {
            var obj = _storage.GetById(id);
            return View("~/Views/Dynamic/Edit.cshtml", obj);
        }

        public IActionResult Save(T entity)
        {
            _storage.AddOrUpdate(entity.Id, entity);
            return RedirectToAction(nameof(Index));
        }
    }
}
