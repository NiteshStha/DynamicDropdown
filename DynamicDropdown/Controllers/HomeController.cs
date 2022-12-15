using DynamicDropdown.Data;
using DynamicDropdown.Models;
using DynamicDropdown.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DynamicDropdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var provinces = await _context.Provinces.ToListAsync();
            var provincesDropItems = provinces.Select(x => new { Id = x.Id, Title = x.Name });
            var provincesDropdown = new SelectList(provincesDropItems, "Id", "Title");

            var model = new IndexViewModel();
            model.ProvinceDrop = provincesDropdown;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> GetDistrictByProvince(int provinceId)
        {
            var district = await _context.Districts.Where(x => x.ProvinceId == provinceId).ToListAsync();
            var districtItems = district.Select(x => new { value = x.Id, text = x.Name });
            return Json(districtItems);
        }

        [HttpPost]
        public async Task<IActionResult> GetMunicipalityByDistrict(int districtId)
        {
            var municipality = await _context.Municipalities.Where(x => x.DistrictId == districtId).ToListAsync();
            var municipalityItems = municipality.Select(x => new { value = x.Id, text = x.Name });
            return Json(municipalityItems);
        }
    }
}