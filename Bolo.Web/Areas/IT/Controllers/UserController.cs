using Bolo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bolo.Web.Areas.IT.Controllers
{
    [Area("IT")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(nameof(Index));
        }
        [HttpGet]
        public IActionResult Get_AccountListAsync()
        {
            var list =  _unitOfWork.userRepository.AccountsAsync();
            return PartialView("_AccountList", list);
        }
    }
}
