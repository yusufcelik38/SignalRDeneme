using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRDeneme.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(string message)
        {
            var hubConnection = new HubConnection("http://localhost:49813/signalr", useDefaultUrl: false);
            IHubProxy hubProxy = hubConnection.CreateHubProxy("FaceHub");
            hubConnection.Start().Wait();


            hubProxy.Invoke("Hello", message).Wait();

            return Json("");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}