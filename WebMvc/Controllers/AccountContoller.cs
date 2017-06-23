namespace WebMvc.Controllers
{
    using Security.IdentityManagementTool.Filters;
    using System.Web;
    using System.Web.Mvc;

    public class AccountController : Controller
    {
        [Auth]
        public ActionResult Login()
        {
            return View();
        }

        [Authorize]
        public ActionResult LogOff()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}