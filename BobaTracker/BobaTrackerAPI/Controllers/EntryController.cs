using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BobaTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : Controller
    {
        [HttpGet]
        public JsonResult GetLastEntry()
        {
            return Json(false);
        }
    }
}
