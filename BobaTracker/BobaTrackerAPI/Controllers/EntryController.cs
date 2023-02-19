using BobaTrackerClassLibrary;
using BobaTrackerClassLibrary.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BobaTrackerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EntryController : Controller
    {
        public EntryRepository entryRepo;

        public EntryController()
        {
            entryRepo = new EntryRepository();
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        public JsonResult GetLastEntry()
        {
            Entry entry;
            try
            {
                entry = entryRepo.GetLastEntry();
            }
            catch (System.Exception)
            {
                entry = null;
            }

            return Json(entry);
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<JsonResult> AddEntry(bool hasPooped, bool hasPeed)
        {
            Entry entry;
            try
            {
                entry = await entryRepo.AddEntry(DateTime.Now, hasPooped, hasPeed);
            }
            catch (System.Exception)
            {
                entry = null;
            }
            return Json(entry);
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<JsonResult> AddCustomEntry(DateTime time, bool hasPooped, bool hasPeed)
        {
            Entry entry;
            try
            {
                entry = await entryRepo.AddEntry(time, hasPooped, hasPeed);
            }
            catch (System.Exception)
            {
                entry = null;
            }
            return Json(entry);
        }

        [EnableCors("MyPolicy")]
        [HttpDelete]
        public async Task<JsonResult> DeleteLastEntry()
        {
            bool status;
            try
            {
                status = await entryRepo.DeleteLastEntry();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = false;
            }
            return Json(status);
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        public JsonResult GetLastPoo()
        {
            try
            {
                var time = entryRepo.GetLastPoo();
                if (time != null) 
                {
                    return Json(time);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Json("NA");
        }


        [EnableCors("MyPolicy")]
        [HttpGet]
        public JsonResult GetLastPee()
        {
            try
            {
                var time = entryRepo.GetLastPee();
                if (time != null) 
                {
                    return Json(time);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Json("NA");
        }
    }
}
