using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using SimpleNotesMVC.ModelDTOs;
using SimpleNotesMVC.Models;
using SimpleNotesMVC.Services.Interfaces;

namespace SimpleNotesMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountInterface _accountInterface;
        public AccountController(IAccountInterface accountInterface)
        {
            _accountInterface = accountInterface;
        }
        // GET: AccountController

        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var loginDto = new LoginModelDTO
            {
                Id=model.Id,
                Email = model.Email,
                Password = model.Password
            };
            var result = _accountInterface.LoginUser(loginDto);
            if (result != null)
            {
                HttpContext.Session.SetInt32("UserId", result.Id);
                HttpContext.Session.SetString("User", result.Email);
                return RedirectToAction("SimpleNotesPage", "Home");
            }
            ViewBag.ErrorMessage = "Invalid credentials";
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match";
                return View(model);
            }
            var addUser = new RegisterModelDTO
            {
                Email = model.Email,
                Password = model.Password,
            };
            var result=_accountInterface.RegisterUser(addUser);
            if (result)
            {
                return RedirectToAction("LoginPage");
            }

            ViewBag.ErrorMessage = "Registration failed";
            return View(model);
        }

        public IActionResult Logout()
        {
           HttpContext.Session.Clear();
            return RedirectToAction("LoginPage", "Account");
        }
    }
}
