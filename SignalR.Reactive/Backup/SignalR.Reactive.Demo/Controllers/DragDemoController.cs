using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using SignalR.Reactive.Demo.Models;

namespace SignalR.Reactive.Demo.Controllers
{
    public class DragDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
