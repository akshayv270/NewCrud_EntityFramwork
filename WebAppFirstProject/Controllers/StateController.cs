using Microsoft.AspNetCore.Mvc;
//using WebApplicationRespository.Concreate;
//using WebApplicationRespository.Interface;
using WebApplicationBussinessServices.Interface;
using WebApplicationBussinessServices.Concreate;
using WebApplocationBussinessEntity;

namespace WebAppFirstProject.Controllers
{
    public class StateController : Controller
    {

        private readonly IStateService stateService;

        public StateController()
        {
            stateService = new StateService();
        }
   
        public IActionResult Index()
        {
            return View(stateService.GetState());
        }
        public IActionResult AddState(int? id)
        {
            if (id.HasValue)
            {
                ViewData["FormTitle"] = "Edit State";
                ViewBag.FormTitle1 = "abc";

                string d = ViewBag.FormTitle1;
                string d1 = Convert.ToString(ViewData["FormTitle"]);

                return View(stateService.GetState(id.Value));
            }
            ViewData["FormTitle"] = "Add State";
            return View();
        }
        [HttpPost]
        public IActionResult AddState(StateViewModel state)
        {

            TempData["message"] = state.Id > 0 ? "User updated sucessfully" : "User save  sucessfully!";

            var p = stateService.AddEditState(state);
            return RedirectToAction("Index");
         
        }
    }
}
