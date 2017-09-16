using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Abstract;
using PartyInvites.Models.ViewModels;

namespace PartyInvites.Components
{
    public class CounterViewComponent : ViewComponent
    {
	    private readonly IRepository _repository;

	    public CounterViewComponent(IRepository repository)
	    {
		    _repository = repository;
	    }

	    public IViewComponentResult Invoke()
	    {
		    var responses = _repository.GetAllResponses().ToList();
		    return View(new CounterViewModel
		    {
			    ResponseAmount = responses.Count,
				AttendingAmount = responses.Count(r => r.WillAttend == true)
		    });
	    }
    }
}
