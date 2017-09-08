using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Linq;
using PartyInvites.Abstract;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IRepository _repository;

	    public HomeController(IRepository repo)
	    {
		    _repository = repo;
	    }

		public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                _repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error
                return View();
            }
        }

        public ViewResult ListResponses()
        {
	        if (_repository.GuestResponses.Count(r => r.WillAttend == true) > 0)
	        {
		        return View(_repository.GuestResponses.Where(r => r.WillAttend == true));
			}
	        else
	        {
				return View("NoResponses");
			}
        }
    }
}
