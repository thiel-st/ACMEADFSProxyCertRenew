using Microsoft.AspNetCore.Mvc;

namespace ADFSProxyCertRenew.WebServer
{
    [Route("")]
    public class SiteController : Controller
    {
        [HttpGet]
        [Route("{acmefile}")]
        public ActionResult GetAcmeFile(string acmefile)
        {
            if (ACMEController.Challenges.ContainsKey(acmefile))
            {
                return this.Content(ACMEController.Challenges[acmefile].HttpResourceValue, ACMEController.Challenges[acmefile].HttpResourceContentType);
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}
