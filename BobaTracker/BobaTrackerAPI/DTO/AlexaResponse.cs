namespace BobaTrackerAPI
{
    public class AlexaResponse
    {
        public string version { get; set; } = "1.0";
        public Response response { get; set; }

        public AlexaResponse(string outputText)
        {
            response = new Response(outputText);
        }

        public AlexaResponse()
        {

        }
    }

    public class Response
    {
#nullable enable
        public OutputSpeech? outputSpeech { get; set; }
        public Reprompt? reprompt { get; set; }
        public bool? shouldEndSession { get; set; }

        public Response(string outputText)
        {
            outputSpeech = new OutputSpeech(outputText);
        }
    }

#nullable enable
    public class Reprompt
    {
        public OutputSpeech? outputSpeech { get; set; }
    }

    public class OutputSpeech
    {
        public string? type { get; set; } = "PlainText";
        public string? text { get; set; }

        public OutputSpeech(string outputText)
        {
            text = outputText;
        }
    }

}
