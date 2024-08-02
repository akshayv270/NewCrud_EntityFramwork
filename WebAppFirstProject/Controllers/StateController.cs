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

        private readonly IStateService c;

        public StateController(IStateService _stateService)
        {
            c = _stateService;
        }
   
        public IActionResult Index()
        {
            return View(c.GetState());
        }

        public IActionResult Index1()
        {
            return View(c.GetState());
        }
        public IActionResult AddState(int? id)
        {
            if (id.HasValue)
            {
                ViewData["FormTitle"] = "Edit State";
                ViewBag.FormTitle1 = "abc";

                string d = ViewBag.FormTitle1;
                string d1 = Convert.ToString(ViewData["FormTitle"]);

                return View(c.GetState(id.Value));
            }
            ViewData["FormTitle"] = "Add State";
            return View();
        }
        [HttpPost]
        public IActionResult AddState(StateViewModel state)
        {

            TempData["message"] = state.Id > 0 ? "User updated sucessfully" : "User save  sucessfully!";

            var p = c.AddEditState(state);
            return RedirectToAction("Index");
         
        }
       [HttpPost]
        public IActionResult DeleteState(int id)
        {
            try
            {
                c.DeleteState(id);
            
            return RedirectToAction("Index");
            }
            catch
            {
                // Handle errors here
                return View("Error");
            }
        }

        public JsonResult Data()
        {
            var p = c.GetState();
            return Json(new {data = p});
        }

        public IActionResult AddEditForm1(int? id)
        {
            if (id.HasValue)
            {
                // Fetch and pass the state model for editing
                var p = c.GetState(id.Value);// Replace with your actual data access logic
                return PartialView("AddEditForm1", p);
            }
            else
            {
      
                return PartialView("AddEditForm1");
            }
        }

        
                public PartialViewResult AddEditForm(int? id)
                {
                    if (id.HasValue)
                    {
                        var p = c.GetState(id.Value);
                        return PartialView(p);
                    }
                    return PartialView();
                }
        
        [HttpPost]
        public JsonResult AddStates(StateViewModel user)
        {
            var p = c.AddEditState(user);
            return Json(new { result = p, message = "State Saved Suc" });
        }

        [HttpPost]
        public JsonResult DeleteInfo(int id)
        {
            var p = c.DeleteState(id);
            return Json(new { result = p, message = "State deleted Suc" });

        }







    }
}
