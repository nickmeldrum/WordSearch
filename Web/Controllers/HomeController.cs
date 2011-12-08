using System.Web.Mvc;
using Model;

namespace Web.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            return View(new WordSearchBox());
        }

        [HttpPost]
        public ActionResult WordList() {
            return Json(new WordList().Words);
        }
    }
}
