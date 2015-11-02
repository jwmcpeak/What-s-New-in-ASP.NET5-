using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MessageApp.Data;
using MessageApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageApp.Controllers
{
    public class MessageController : Controller
    {
        private MessageRepository _messages = new MessageRepository();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_messages.All());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var message = _messages.Get(id);

            if (message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Message model)
        {
            var message = _messages.Get(model.Id);

            if (message == null)
            {
                return HttpNotFound();
            }

            _messages.Update(model);

            return RedirectToAction("index");
        }

    }
}
