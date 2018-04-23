using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpressMvcApplication1.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";
			ViewData["selectedRows"] = new int[] { 1, 5, 9, 4, 11, 17, 34, 77 };
			return View(NorthwindDataProvider.GetProducts());
		}
		public ActionResult InlineEditingPartial() {
			return PartialView("GridView", NorthwindDataProvider.GetEditableProducts());
		}
	}
}
