using Company.Data.Entities;
using Complany.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Complany.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Application> _userManager;
        public AccountController(UserManager<Application> userManager) 
        { 
            _userManager = userManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModels input)
        {
            if (ModelState.IsValid)
            {
            var user = new Application
            {
                UserName = input.Email.Split("@")[0],
                Email = input.Email,
                FirstName = input.FirstName,
                LastName = input.LastName,
                IsActive = true
            };
                var result = await _userManager.CreateAsync(user, input.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignUp");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(input);

        }
    }
}
