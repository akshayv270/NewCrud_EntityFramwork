using Microsoft.AspNetCore.Mvc;
using WebApplicationRespository.Concreate;
using WebApplicationRespository.Interface;

namespace WebAppFirstProject.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateRepository stateRepository;

        public StateController()
        {
            stateRepository = new StateRepository();
        }
        public IActionResult Index()
        {
            return View(stateRepository.GetStates());
        }
    }
}
