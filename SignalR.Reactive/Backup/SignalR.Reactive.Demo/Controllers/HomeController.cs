using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using SignalR.Reactive.Demo.Models;

namespace SignalR.Reactive.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void DoALongRunningOperation(string id)
        {
            var subject = new Subject<string>();

            Task.Factory.StartNew(() =>
            {
                subject.OnNext("just started");
                Thread.Sleep(1000);
                subject.OnNext("One second passed, I'm still running");
                Thread.Sleep(5000);
                subject.OnNext("Another five seconds passed, I'm still running");
                Thread.Sleep(5000);
                subject.OnNext("Almost done");
                subject.OnCompleted();
            });

            subject.ToClientside().Observable<RxHub>(id);
        }
    }
}
