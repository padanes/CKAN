using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;

namespace CKAN.NetKAN
{
    /// <summary>
    /// Converts AVC style KSP versions into CKAN ones.
    /// </summary>
    public class JsonAvcToKspVersion : JsonConverter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (JsonAvcToKspVersion));

        public override bool CanConvert(Type object_type)
        {
            // We trust you only to call this on things we can convert, okay?
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            log.DebugFormat ("Read Token: {0}, {1}", new Object[] { token.Type, token.ToString() });
            if (token.Type != JTokenType.Object)
            {
                throw new InvalidCastException ("Trying to convert non-JSON object to KSP version object");
            }

            // This gives us something like "0.25.0"
            string version = string.Join (".", token ["MAJOR"], token ["MINOR"], token ["PATCH"]);

            return new KSPVersion (version);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// Converts AVC style versions into CKAN ones.
    /// </summary>
    public class JsonAvcToVersion : JsonConverter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (JsonAvcToKspVersion));

        public override bool CanConvert(Type object_type)
        {
            // We trust you only to call this on things we can convert, okay?
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            log.DebugFormat ("Read Token: {0}, {1}", new Object[] { token.Type, token.ToString() });
            if (token.Type != JTokenType.Object)
            {
                throw new InvalidCastException("Trying to convert non-JSON object to Version object");
            }

            // This gives us something like "0.25.0"
            string version = string.Join(".", token["MAJOR"], token["MINOR"], token["PATCH"]);

            return new Version(version);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
}

