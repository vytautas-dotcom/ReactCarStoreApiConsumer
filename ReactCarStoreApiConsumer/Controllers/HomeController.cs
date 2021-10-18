using Microsoft.AspNetCore.Mvc;
using ReactCarStoreApiConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCarStoreApiConsumer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository _storeRepository;

        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("stores")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IList<Store>> Stores()
        {
            return await _storeRepository.GetStoreList();
        }
    }
}
