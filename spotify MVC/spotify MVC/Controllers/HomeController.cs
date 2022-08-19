using Microsoft.AspNetCore.Mvc;
using spotify_MVC.Models;
using SpotifyAPI.Web;
using System.Diagnostics;

namespace spotify_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator("44dc3df445894b2e95eda36bd59c892d",
                "2ac5fbc05fda4368b994fdb616087cb1"));
            var spotify = new SpotifyClient(config);

            FeaturedPlaylistsResponse track = await spotify.Browse.GetFeaturedPlaylists();
            var track2 = await spotify.Browse.GetNewReleases();
            //Console.WriteLine(track.Artists[0].Name + " - " + track.Name);
            ViewBag.track = track;
            return View();
        }

        public async Task<IActionResult> Index2()
        {
            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator("44dc3df445894b2e95eda36bd59c892d",
                "2ac5fbc05fda4368b994fdb616087cb1"));
            var spotify = new SpotifyClient(config);

            NewReleasesResponse track2 = await spotify.Browse.GetNewReleases();
            //Console.WriteLine(track.Artists[0].Name + " - " + track.Name);
            ViewBag.track = track2;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}