using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Service;
using ProgressTracker.Service.Interfaces;
using ProgressTracker.Web.Models;

namespace ProgressTracker.Web.Controllers
{
    public class MetricsController : Controller
    {
        private readonly ILogger<MetricsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMetricService _metricService;

        public MetricsController(ILogger<MetricsController> logger, IMapper mapper, IMetricService MetricService)
        {
            _logger = logger;
            _mapper = mapper;
            _metricService = MetricService;
        }

        public IActionResult Index()
        {
            List<Metric> metrics = _metricService.GetAll();
            List<MetricViewModel> viewModel = _mapper.Map<List<Metric>, List<MetricViewModel>>(metrics);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MetricViewModel viewModel)
        {
            _logger.LogInformation("{DateTime} - A metric was created: {viewModel}", viewModel, DateTime.UtcNow.ToString());
            Metric Metric = _mapper.Map<MetricViewModel, Metric>(viewModel);
            _metricService.Create(Metric);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Metric? Metric = _metricService.GetOneBy<int>("Id", id);
            MetricViewModel viewModel = _mapper.Map<Metric, MetricViewModel>(Metric);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(MetricViewModel viewModel)
        {
            Metric Metric = _mapper.Map<MetricViewModel, Metric>(viewModel);
            _metricService.Update(Metric);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Metric? metric = _metricService.GetOneBy<int>("Id", id);
            MetricViewModel viewModel = _mapper.Map<Metric, MetricViewModel>(metric);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(MetricViewModel viewModel)
        {
            Metric Metric = _mapper.Map<MetricViewModel, Metric>(viewModel);
            _metricService.Delete(Metric);
            return RedirectToAction("Index");
        }


    }
}
