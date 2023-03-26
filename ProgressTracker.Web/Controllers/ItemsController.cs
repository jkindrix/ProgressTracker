using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Service;
using ProgressTracker.Web.Models;

namespace ProgressTracker.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IMapper _mapper;
        private readonly IItemService _itemService;

        public ItemsController(ILogger<ItemsController> logger, IMapper mapper, IItemService itemService)
        {
            _logger = logger;
            _mapper = mapper;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItemCreateViewModel viewModel)
        {
            _logger.LogInformation($"An item was created: {viewModel}", DateTime.UtcNow.ToString());
            Item item = _mapper.Map<Item>(viewModel);
            _itemService.CreateItem(item);
            return RedirectToAction("Index");
        }
    }
}
