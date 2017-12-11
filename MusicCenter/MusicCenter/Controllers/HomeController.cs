using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LastFM;
using System.Collections.Generic;
using MusicCenter.Models;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.Xml.Linq;
using HtmlAgilityPack;
using System;
using MusicCenter.Models.ManageViewModels;
using Microsoft.AspNetCore.Identity;

namespace MusicCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public OnlineWorker onlineWorker;
        [TempData]
        public string StatusMessage { get; set; }
        public HomeController(UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            onlineWorker = new OnlineWorker();
        }

        public async Task<IActionResult> Index(int? numPage)
        {
            int tempPage = numPage ?? 1;
            var searchresult = new SearchResult() { SearchReqest = ""};
            searchresult.Artists.AddRange(await onlineWorker.TopArtistsForViewAsync(tempPage));
            searchresult.Albums.AddRange(await onlineWorker.TopAlbumsForViewAsync(tempPage));
            searchresult.Tracks.AddRange(await onlineWorker.TopTracksForViewAsync(tempPage));
            return View(searchresult);
        }

        [HttpPost]
        public string GetDiv(string text)
        {
            var webClient = new WebClient();
            string returning;
            using (webClient)
            {
                return returning = webClient.DownloadString(text);
            }
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
