using System;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Infrastructure;
using WebUi.Lib;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;

        public HomeController(IEscortRepository escortRepository,
            ITextRepository textRepository,
            IMenuRepository menuRepository,
            IMapper mapper,
            IWebHostEnvironment env,
            IMemoryCache memoryCache,
            IHttpContextAccessor httpContextAccessor,
            ILogger<HomeController> logger) : base (escortRepository, textRepository, menuRepository, memoryCache)
        {
            _logger = logger;
            _mapper = mapper;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

#if !DEBUG
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, NoStore = false)]
#endif
        public async Task<IActionResult> Index(string name)
        {
            //var m = new HomeViewModel();
            //var escorts = await GetAllEscorts();
            //foreach (var p in escorts)
            //{
            //    m.List.Add(_mapper.Map<HomeViewItem>(p));
            //}
            
            //var list = await GetAllTexts();

            //m.PositionHomeTopTitle = list
            //    .Where(z => z.Position == "PositionHomeTopTitle").Select(z => z.Description)
            //    .FirstOrDefault();
            //m.PositionHomeTop = list
            //    .Where(z => z.Position == "PositionHomeTop").Select(z => z.Description)
            //    .FirstOrDefault();
            //m.PositionHomeBottom = list
            //    .Where(z => z.Position == "PositionHomeBottom").Select(z => z.Description)
            //    .FirstOrDefault();

            //ViewBag.BackGroundImage = "bg_home.jpg";
            ViewBag.CanonicalUrl = GetCanonicalUrl();
            ViewBag.SiteTitle = "Las Vegas Independent Escorts Of VegasIndependents";
            ViewBag.SiteDescription =
                "Las Vegas escorts will give you a time that you will never forget as long as you live. Choosing the best one is easy here – VegasIndependents";

            //ViewBag.MenuEscorts = await GetAllMenu();

            //ViewBag.GoogleAnalyticsObject = list
            //    .Where(z => z.Position == "GoogleAnalyticsObject").Select(z => z.Description)
            //    .FirstOrDefault();

            return View();
        }

        private string GetCanonicalUrl()
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var request = _httpContextAccessor.HttpContext.Request;
                return string.Concat(
                    request.Scheme,
                    "://",
                    request.Host.ToUriComponent(),
                    request.PathBase.ToUriComponent(),
                    request.Path.ToUriComponent(),
                    request.QueryString.ToUriComponent());
            }

            return string.Empty;
        }

#if !DEBUG
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, NoStore = false)]
#endif
        [Route("london-escorts.php")]
        public IActionResult LondonEscorts()
        {
            return View();
        }

#if !DEBUG
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, NoStore = false)]
#endif
        [Route("manchester-escorts.php")]
        public IActionResult ManchesterEscorts()
        {
            return View();
        }

#if !DEBUG
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, NoStore = false)]
#endif
        [Route("birmingham-escorts.php")]
        public IActionResult BirminghamEscorts()
        {
            return View();
        }

#if !DEBUG
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, NoStore = false)]
#endif
        [Route("liverpool-escorts.php")]
        public IActionResult LiverpoolEscorts()
        {
            return View();
        }

#if !DEBUG
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, NoStore = false)]
#endif
        [Route("bristol-escorts.php")]
        public IActionResult BristolEscorts()
        {
            return View();
        }

#if !DEBUG
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, NoStore = false)]
#endif
        [Route("about.php")]
        public IActionResult AboutUs()
        {            
            ViewBag.CanonicalUrl = GetCanonicalUrl();
            ViewBag.SiteTitle = "Read about VegasIndependents - the best escorts in Las Vegas";
            ViewBag.SiteDescription = "Welcome to VegasIndependents. We are the most reputable and well known site in Las Vegas. Find out more about us.";

            return View();
        }

        public async Task<IActionResult> Massage(string name)
        {
            var m = new MassageViewModel();
            
            var escorts = await GetAllEscorts();
            var texts = await GetAllTexts();
            var list = new List<Escort>();

            switch (name)
            {
                case "asia-massage":
                    list = escorts.Where(z => z.Nationality == "Asian").ToList();
                    break;
                case "erotic-massage":
                    list = escorts.Where(z => z.Nationality == "Erotic").ToList();
                    break;
                case "couples-massage":
                    list = escorts.Where(z => z.Nationality == "Couples").ToList();
                    break;
                case "nuru-massage":
                    list = escorts.Where(z => z.Nationality == "Nuru").ToList();
                    break;
                case "happy-ending-massage":
                    list = escorts.Where(z => z.Nationality == "Happy Ending").ToList();
                    break;
                case "nude-massage":
                    list = escorts.Where(z => z.Nationality == "Nude").ToList();
                    break;
                case "body-massage":
                    list = escorts.Where(z => z.Nationality == "Body Rubs").ToList();
                    break;
            }

            var s = name.Replace("-", " ");
            m.EscortsNavTitle = Regex.Replace(s, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

            m.PositionMassageTitle = texts.Where(z => z.Position == $"Massage-{name}-Title").Select(z => z.Description)
                .FirstOrDefault();
            m.PositionMassageTop = texts.Where(z => z.Position == $"Massage-{name}-Top").Select(z => z.Description)
                .FirstOrDefault();
            m.PositionMassageBottom = texts.Where(z => z.Position == $"Massage-{name}-Bottom").Select(z => z.Description)
                .FirstOrDefault();
            ViewBag.SiteTitle = texts.Where(z => z.Position == $"Massage-{name}-SiteTitle").Select(z => z.Description)
                .FirstOrDefault();
            ViewBag.SiteDescription = texts.Where(z => z.Position == $"Massage-{name}-SiteDescription").Select(z => z.Description)
                .FirstOrDefault();
            
            foreach (var i in list.Select(p => _mapper.Map<HomeViewItem>(p)))
            {
                m.List.Add(i);
            }

            ViewBag.BackGroundImage = $"{WorkLib.GetRandomNumber(2, 14)}.jpg";
            ViewBag.CanonicalUrl = GetCanonicalUrl();
            ViewBag.MenuEscorts = await GetAllMenu();
            ViewBag.GoogleAnalyticsObject = texts.Where(z => z.Position == "GoogleAnalyticsObject").Select(z => z.Description)
                .FirstOrDefault();

            return View("Massage",m);
        }

#if !DEBUG
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, NoStore = false)]
#endif
        [Route("{name}")]
        public async Task<IActionResult> Escorts(string name)
        {
            var texts = await GetAllTexts();
            ViewBag.CanonicalUrl = GetCanonicalUrl();

            switch (name)
            {
                case "asian-escorts.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleAsian").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionAsian").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("asian-escorts");

                case "black-escorts.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleBlack").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionBlack").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("black-escorts");

                case "blonde-escorts.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleBlondeEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionBlondeEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("blonde-escorts");

                case "russian-escorts.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleRussianEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionRussianEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("russian-escorts");

                case "vip-escorts.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleVipEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionVipEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("vip-escorts");

                case "female-escorts.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleFemaleEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionFemaleEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("female-escorts");

                case "young-escorts.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleYoungEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionYoungEscorts").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("young-escorts");

                case "erotic-massage.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleEroticMassage").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionEroticMassage").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("erotic-massage");

                case "body-rubs.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleBodyRubs").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionBodyRubs").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("body-rubs");

                case "bachelor-party.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitlebBchelorParty").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionBchelorParty").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("bachelor-party");

                case "nuru-massage.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleNuruMassage").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionNuruMassage").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("nuru-massage");
                case "happy-ending-massage.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleHappyMassage").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionHappyMassage").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("happy-ending-massage");
                case "fbsm-massage.php":
                    ViewBag.SiteTitle = texts.Where(z => z.Position == "SiteTitleFBSMMassage").Select(z => z.Description)
                        .FirstOrDefault();
                    ViewBag.SiteDescription = texts.Where(z => z.Position == "SiteDescriptionFBSMMassage").Select(z => z.Description)
                        .FirstOrDefault();
                    return View("fbsm-massage");

                default: return RedirectToAction("Error");
            }
        }

        [Route("robots.txt")]
        public ContentResult RobotsTxt()
        {
            var filePath = Path.Combine(_env.WebRootPath,"robots.txt");
            var s = System.IO.File.ReadAllText(filePath);
            return this.Content(s, "text/plain", Encoding.UTF8);
        }

        [Route("sitemap.xml")]
        public ContentResult SiteMap()
        {
            var filePath = Path.Combine(_env.WebRootPath, "sitemap.xml");
            var s = System.IO.File.ReadAllText(filePath);
            return this.Content(s, "text/plain", Encoding.UTF8);
        }

        private async Task<string> GetEscortsHeading(string position)
        {
            var texts = await GetAllTexts();
            return texts.Where(z => z.Position == position)
                .Select(z => z.Description).FirstOrDefault();
        }

        [Route("{seg1?}/{seg2}")]
        public IActionResult BadUrl()
        {
            return RedirectToAction("Error");
        }

        [Route("404.php")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            ViewBag.BackGroundImage = $"{WorkLib.GetRandomNumber(2, 14)}.jpg";
            ViewBag.CanonicalUrl = GetCanonicalUrl();

            ViewBag.SiteTitle = "";
            ViewBag.SiteDescription = "";

            Response.StatusCode = 404;

            ViewBag.MenuEscorts = await GetAllMenu();

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class HomeViewModel
    {
        public string PositionHomeTopTitle { get; set; }
        public string PositionHomeTop { get; set; }
        public string PositionHomeBottom { get; set; }
        public List<HomeViewItem> List { get; set; } = new List<HomeViewItem>();
    }

    public class EscortsViewModel
    {
        public string EscortsHeading { get; set; }
        public string EscortsNavTitle { get; set; }
        public string PositionEscortsTop { get; set; }
        public string PositionEscortsBottom { get; set; }
        public List<HomeViewItem> List { get; set; } = new List<HomeViewItem>();
    }

    public class MassageViewModel
    {
        public string EscortsNavTitle { get; set; }
        public string PositionMassageTitle { get; set; }
        public string PositionMassageTop { get; set; }
        public string PositionMassageBottom { get; set; }
        public List<HomeViewItem> List { get; set; } = new List<HomeViewItem>();
    }

    public class BodyRubsViewModel
    {
        public string PositionBodyRubsTitle { get; set; }
        public string PositionBodyRubsTop { get; set; }
        public string PositionBodyRubsBottom { get; set; }
        public List<HomeViewItem> List { get; set; } = new List<HomeViewItem>();
    }

    public class AboutUsViewModel
    {
        public string PositionAbout { get; set; }
        public string SiteDescriptionAbout { get; set; }
        public List<HomeViewItem> List { get; set; } = new List<HomeViewItem>();
    }

    public class HomeViewItem : Escort
    {
        
    }
}
