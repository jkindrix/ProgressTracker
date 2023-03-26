using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Service;
using ProgressTracker.Service.Interfaces;
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
            List<Item> items = _itemService.GetAllItems();
            List<ItemViewModel> viewModel = _mapper.Map<List<Item>, List<ItemViewModel>>(items);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItemViewModel viewModel)
        {
            _logger.LogInformation("{DateTime} - An item was created: {viewModel}", viewModel, DateTime.UtcNow.ToString());
            Item item = _mapper.Map<ItemViewModel, Item>(viewModel);
            _itemService.Create(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Item? item = _itemService.GetItemById(id);
            ItemViewModel viewModel = _mapper.Map<Item, ItemViewModel>(item);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ItemViewModel viewModel)
        {
            Item item = _mapper.Map<ItemViewModel, Item>(viewModel);
            _itemService.Update(item);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Item? item = _itemService.GetItemById(id);
            ItemViewModel viewModel = _mapper.Map<Item, ItemViewModel>(item);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(ItemViewModel viewModel)
        {
            Item item = _mapper.Map<ItemViewModel, Item>(viewModel);
            _itemService.Delete(item);
            return RedirectToAction("Index");
        }


    }
}
