using Microsoft.AspNetCore.Mvc;

namespace MedicinalPlants.WebUI.Controllers
{
	public class LayoutController : Controller
	{
		public PartialViewResult FooterPartial()
		{
			return PartialView();
		}
		public PartialViewResult HeadPartial()
		{
			return PartialView();
		}

		public PartialViewResult SidebarPartial()
		{
			return PartialView();
		}
		public PartialViewResult ScriptPartial()
		{
			return PartialView();
		}
	}
}
