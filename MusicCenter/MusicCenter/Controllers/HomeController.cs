using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MusicCenter.Models;

namespace MusicCenter.Controllers
{
    public class HomeController : Controller
    {
        public OnlineWorker onlineWorker;

        public HomeController()
        {
            onlineWorker = new OnlineWorker();
        }

        public ActionResult Index(int? author)
        {
            ViewBag.reqest = "Search";
            int numPage = author ?? 1;
            if (Request.IsAjaxRequest() && numPage != 1)
            {
                return PartialView("_Items", onlineWorker.TopAuthorsForView(numPage));
            }
            return View(onlineWorker.TopAuthorsForView(numPage));
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
