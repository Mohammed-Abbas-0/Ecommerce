using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data.Repositories.IRepositoryInterface;
using Tickets.DatabaseContext;
using Tickets.Models;

namespace Tickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActor actorContext;
        public ActorController(IActor _actor) => actorContext = _actor;
        
        public async Task<IActionResult> Index()
        {
            var actorService = await actorContext.GetAll();
            return View(actorService);
        }

        #region C R E A T E
        // GET
        public IActionResult Create()
        {
            return View();
        }
        // Post
        [HttpPost]

        public IActionResult Create([Bind("ProfilePictureURL,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
                return View(actor);
            actorContext.Add(actor);
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region D E T A I L
        // GET
        public async Task<IActionResult> Detail(int Id)
        {
            Actor getActor = await actorContext.GetById(Id);
            if (getActor is null)
                return View("Empty");
            return View(getActor);
        }
        #endregion

        #region D E L E T E

        [HttpPost]
        public async Task<JsonResult> Delete(int Id)
        {
            bool actorIsDeleted = await actorContext.Delete(Id);
            if(actorIsDeleted)
                return Json("Success");
            else   
                return Json("danger");
        }

        #endregion
    }
}
