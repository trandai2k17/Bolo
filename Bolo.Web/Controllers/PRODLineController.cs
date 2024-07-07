using Bolo.Application.Interfaces;
using Bolo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bolo.Web.Controllers
{
    public class PRODLineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PRODLineController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ProdLineVM()
            {
                ProdLines = await _unitOfWork.ProductionLineRepo.LocationsAsync()
            };

            return View(model);
        }
    }
}
