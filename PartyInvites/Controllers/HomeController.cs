using Microsoft.AspNetCore.Mvc;
using PartyInvites.Interfaces;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        //right click ViewResult -> new view
        public ViewResult RsvpForm()
        {
            return View();
        }


        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GuestResponse.Add(guestResponse); //Adds this guest response table
                _unitOfWork.Commit();
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }


        //not included in the copy/paste doc
        public ViewResult ListResponses()
        {
            return View(_unitOfWork.GuestResponse.List(gr => gr.WillAttend == true)); //go to guest response, convert into a list, convert it into a guest response object if they WillAttend
            //return View(Repository.Responses.Where(r => r.WillAttend == true));//return a view of the same name
        }


    }
}
