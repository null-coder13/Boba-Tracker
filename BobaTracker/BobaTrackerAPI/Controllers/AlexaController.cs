using System.IO;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using BobaTrackerClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BobaTrackerClassLibrary.Models;

namespace BobaTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaController : Controller
    {
        public EntryRepository entryRepo;
        private readonly ILogger<AlexaController> _logger;

        public AlexaController(ILogger<AlexaController> logger)
        {
            entryRepo = new EntryRepository();
            _logger = logger;
        }

        [HttpGet]
        public void Get() {}

        [HttpPost]
        public async Task<AlexaResponse> Post()
        {
            using var streamReader = new StreamReader(Request.Body);
            var json = await streamReader.ReadToEndAsync();
            _logger.LogInformation(json);
            var alexaRequest = JsonSerializer.Deserialize<AlexaRequest>(json);

            if (alexaRequest.request.type == "SessionEndedRequest")
            {
                _logger.LogInformation("Session Ended");
                return new AlexaResponse();
            }

            var intent = alexaRequest.request.intent.name;

            _logger.LogInformation(alexaRequest.request.intent.name);

            return GenerateValidResponse(intent);
        }

        public AlexaResponse GenerateValidResponse(string intent)
        {
            string speech;
            switch (intent)
            {
                case "GetLastEntryIntent":
                    _logger.LogInformation("Last Bathroom intent invoked");
                    Entry entry = entryRepo.GetLastEntry();
                    speech = GenerateSpeech("went outside", entry.DateTimeId);
                    return new AlexaResponse(speech);
                case "GetLastPeeIntent":
                    _logger.LogInformation("Last Pee intent invoked");
                    speech = GenerateSpeech("peed", (DateTime) entryRepo.GetLastPee());
                    return new AlexaResponse(speech);
                case "GetLastPooIntent":
                    _logger.LogInformation("Last Poo intent invoked");
                    speech = GenerateSpeech("pooped", (DateTime) entryRepo.GetLastPoo());
                    return new AlexaResponse(speech);
                default:
                    return new AlexaResponse();
            }
        }

        public string GenerateSpeech(string pottyType, DateTime date)
        {
            return $"Boba last {pottyType} on {date.DayOfWeek} at {date.ToString("h:mm tt")}";
        }
    }
}
