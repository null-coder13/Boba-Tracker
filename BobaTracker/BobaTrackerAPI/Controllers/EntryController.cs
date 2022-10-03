using BobaTrackerClassLibrary;
using BobaTrackerClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public JsonResult AddEntry(bool hasPooped, bool hasPeed)
        {
            bool status;
            try
            {
                status = entryRepo.AddEntry(DateTime.Now, hasPooped, hasPeed);
            }
            catch (System.Exception)
            {
                status = false;
            }
            return Json(status);
        }
    }
}
