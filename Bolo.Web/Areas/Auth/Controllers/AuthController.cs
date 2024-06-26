using Bolo.Application.Interfaces;
using Bolo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bolo.Web.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public AuthController(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Register()
        {
            Account model = new Account();
            return View(nameof(Register), model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(Account account)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterAsync(account);
                if (result)
                {
                    await _authService.SignInAsync(account);
                    return Redirect(account.ReturnUrl);
                }

            }
            Account model = new Account();
            return View(nameof(Register), account);
        }
        public IActionResult Login(string ReturnUrl = null)
        {
            Account model = new Account()
            {
                ReturnUrl = ReturnUrl ?? "~"
            };
            return View(nameof(Login), model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(Account model, string ReturnUrl)
        {
            var result = await _authService.SignInAsync(model);
            if (result)
            {
                //string url = ControllerContext.HttpContext.Request.GetDisplayUrl();
                return Redirect(ReturnUrl == "~" ? "/" : "~" + ReturnUrl);
            }
            return View(nameof(Login), model);
        }
        //[Authorize]
        //public async Task<IActionResult> Accounts()
        //{
        //   var users = new List<UserInfo>();
        //    users = await _unitOfWork.AccountRepo.AccountsAsync();
        //    return View(nameof(Accounts), users);
        //}
        //[HttpPost]
        //public async Task<IActionResult> RegisterIdentity(SYSUserTable model)
        //{
        //    List<SYSUserTable> users = new List<SYSUserTable>();
        //    //users = await _db.SYSUserTableDB.ToListAsync();

        //    return View(nameof(Accounts), users);
        //}

        public async Task<IActionResult> Logout()
        {
            await _authService.SignOutAsync();

            return Redirect("~/Home");
        }


        public async Task<IActionResult> CreateAccount(Employee EmplID)
        {
            Account account = new Account();
            return View(nameof(Register), account);
        }
    }
}
