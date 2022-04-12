using _16_March.Models;
using _16_March.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _16_March.Controllers
{
    public class CacheController : Controller
    {
        private readonly IService<Department, int> deptServ;
        private readonly IMemoryCache _memoryCache;

        public CacheController(IService<Department, int> deptServ, IMemoryCache memoryCache)
        {
            this.deptServ = deptServ;
            this._memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            // 1. Set the Cache Key: The Identification of Data in Cache
            var cacheKey = "deptList";
            List<Department> depts = null;
            // Get data from the database
            List<Department> departments;
           
            // if the Data is not present into cache add it in cache
            if (!_memoryCache.TryGetValue(cacheKey, out depts))
            {
                depts = deptServ.GetAsync().Result.ToList();
                /// Define the Cache COnfiguration
                var cacheExpiryOptions = new MemoryCacheEntryOptions()
                {
                    // LIfetime of data in Cache
                    AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                    // 
                    Priority = CacheItemPriority.High,
                    // CLeanup the Cache with Updates
                    SlidingExpiration = TimeSpan.FromSeconds(20)

                };
                ViewBag.Message = "Data is Received from the Database";
    
                // Add data into the cache
                _memoryCache.Set(cacheKey, depts, cacheExpiryOptions);
                return View(depts);
            }
            else
            {
                depts = deptServ.GetAsync().Result.ToList();
                ViewBag.Message = "Data is Received from the Cache";
                return View(depts);
            }



        }
    }
}
