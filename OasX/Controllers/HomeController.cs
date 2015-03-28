using System;
using System.Linq;
using System.Web.Mvc;
using OasX.Domain.Application;
using OasX.Service.Interfaces;

namespace OasX.Controllers
{
    public class HomeController : Controller
    {
        private IManagementService _managementService;

        public HomeController(IManagementService managementService) {
            _managementService = managementService;
        }

        [AllowAnonymous]
        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) {
                var topNews = _managementService.GetTopNews(1).ToArray();
                var topNew = topNews.Length == 0
                    ? new News {Content = "Empty", Title = "Empty", PublishedDate = DateTime.Now}
                    : topNews[0];
                return View(topNew);
            }

            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact() {
            return View();
        }
    }
}