namespace Mango.Web.Controllers
{
    using Mango.Web.Models;
    using Mango.Web.Models.AuthDtos;
    using Mango.Web.Service.IService;
    using Mango.Web.Utility;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Newtonsoft.Json;

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();

            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponceDto responceDto = await _authService.LoginAsync(obj);

            if (responceDto != null && responceDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responceDto.Result));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", responceDto.Message);

                return View(obj);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = SD.RoleAdmin, Value=SD.RoleAdmin},
                new SelectListItem(){Text = SD.RoleCustomer, Value=SD.RoleCustomer},
            };

            ViewBag.RoleList = roleList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {
            
            ResponceDto result = await _authService.RegisterAsync(obj);
            ResponceDto assignRole;

            if (result != null || result.IsSuccess)
            {
                if (string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = SD.RoleCustomer;
                }

                assignRole = await _authService.AssignRoleAsync(obj);

                if (assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";

                    return RedirectToAction(nameof(Login));
                }
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = SD.RoleAdmin, Value=SD.RoleAdmin},
                new SelectListItem(){Text = SD.RoleCustomer, Value=SD.RoleCustomer},
            };

            ViewBag.RoleList = roleList;

            return View(obj);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
