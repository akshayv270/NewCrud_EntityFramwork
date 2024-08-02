using WebApplicationBussinessServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebAppFirstProject.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View(userService.GetUser());
        }

        public  JsonResult GetData()
        {
            var d = userService.GetUser();
            return Json(new { data = d });
        }
    }
}
