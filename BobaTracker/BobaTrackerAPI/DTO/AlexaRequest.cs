using System;

namespace BobaTrackerAPI
{
    public class AlexaRequest
    {
        public string version { get; set; }
        public Session session { get; set; }
        public Context context { get; set; }
        public Request request { get; set; }
    }

    public class Session
    {
        public bool _new { get; set; }
        public string sessionId { get; set; }
        public Application application { get; set; }
        public Attributes attributes { get; set; }
        public User user { get; set; }
    }

    public class Application
    {
        public string applicationId { get; set; }
    }

    public class Attributes
    {
    }

    public class User
    {
        public string userId { get; set; }
    }

    public class Context
    {
        public Viewport1[] Viewports { get; set; }
        public Viewport Viewport { get; set; }
        public Extensions Extensions { get; set; }
        public Advertising Advertising { get; set; }
        public System System { get; set; }
    }

    public class Viewport
    {
        public Experience[] experiences { get; set; }
        public string mode { get; set; }
        public string shape { get; set; }
        public int pixelWidth { get; set; }
        public int pixelHeight { get; set; }
        public int dpi { get; set; }
        public int currentPixelWidth { get; set; }
        public int currentPixelHeight { get; set; }
        public string[] touch { get; set; }
        public Video video { get; set; }
    }

    public class Video
    {
        public string[] codecs { get; set; }
    }

    public class Experience
    {
        public int arcMinuteWidth { get; set; }
        public int arcMinuteHeight { get; set; }
        public bool canRotate { get; set; }
        public bool canResize { get; set; }
    }

    public class Extensions
    {
        public Available available { get; set; }
    }

    public class Available
    {
        public AplextBackstack10 aplextbackstack10 { get; set; }
    }

    public class AplextBackstack10
    {
    }

    public class Advertising
    {
        public string advertisingId { get; set; }
        public bool limitAdTracking { get; set; }
    }

    public class System
    {
        public Application1 application { get; set; }
        public User1 user { get; set; }
        public Device device { get; set; }
        public string apiEndpoint { get; set; }
        public string apiAccessToken { get; set; }
    }

    public class Application1
    {
        public string applicationId { get; set; }
    }

    public class User1
    {
        public string userId { get; set; }
    }

    public class Device
    {
        public string deviceId { get; set; }
        public Supportedinterfaces supportedInterfaces { get; set; }
    }

    public class Supportedinterfaces
    {
    }

    public class Viewport1
    {
        public string type { get; set; }
        public string id { get; set; }
        public string shape { get; set; }
        public int dpi { get; set; }
        public string presentationType { get; set; }
        public bool canRotate { get; set; }
        public Configuration configuration { get; set; }
    }

    public class Configuration
    {
        public Current current { get; set; }
    }

    public class Current
    {
        public string mode { get; set; }
        public Video1 video { get; set; }
        public Size size { get; set; }
    }

    public class Video1
    {
        public string[] codecs { get; set; }
    }

    public class Size
    {
        public string type { get; set; }
        public int pixelWidth { get; set; }
        public int pixelHeight { get; set; }
    }

    public class Request
    {
        public string type { get; set; }
        public string requestId { get; set; }
        public string locale { get; set; }
        public DateTime timestamp { get; set; }
        public Intent intent { get; set; }
    }

    public class Intent
    {
        public string name { get; set; }
        public string confirmationStatus { get; set; }
        public Slots slots { get; set; }
    }

    public class Slots
    {
        public Bathroom_Type Bathroom_Type { get; set; }
    }

    public class Bathroom_Type
    {
        public string name { get; set; }
        public string value { get; set; }
        public Resolutions resolutions { get; set; }
        public string confirmationStatus { get; set; }
        public string source { get; set; }
        public Slotvalue slotValue { get; set; }
    }

    public class Resolutions
    {
        public Resolutionsperauthority[] resolutionsPerAuthority { get; set; }
    }

    public class Resolutionsperauthority
    {
        public string authority { get; set; }
        public Status status { get; set; }
        public Value[] values { get; set; }
    }

    public class Status
    {
        public string code { get; set; }
    }

    public class Value
    {
        public Value1 value { get; set; }
    }

    public class Value1
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Slotvalue
    {
        public string type { get; set; }
        public string value { get; set; }
        public Resolutions1 resolutions { get; set; }
    }

    public class Resolutions1
    {
        public Resolutionsperauthority1[] resolutionsPerAuthority { get; set; }
    }

    public class Resolutionsperauthority1
    {
        public string authority { get; set; }
        public Status1 status { get; set; }
        public Value2[] values { get; set; }
    }

    public class Status1
    {
        public string code { get; set; }
    }

    public class Value2
    {
        public Value3 value { get; set; }
    }

    public class Value3
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}
