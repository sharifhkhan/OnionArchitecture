namespace Onion.Infrastructure.Services
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    public class JsonNetFormatter : MediaTypeFormatter
    {
        public JsonNetFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            // var jsonSerializerSettings = new JsonSerializerSettings
            // {
            // PreserveReferencesHandling = PreserveReferencesHandling.Objects 
            // };
        }

        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            // don't serialize JsonValue structure use default for that
            if (type == typeof(JValue) || type == typeof(JObject) || type == typeof(JArray))
            {
                return false;
            }

            return true;
        }

        public override Task<object> ReadFromStreamAsync(
            Type type, Stream stream, HttpContent content, IFormatterLogger formatterLogger)
        {
            Task<object> task = Task<object>.Factory.StartNew(
                () =>
                    {
                        var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, };

                        var sr = new StreamReader(stream);
                        var jreader = new JsonTextReader(sr);

                        var ser = new JsonSerializer();
                        ser.Converters.Add(new IsoDateTimeConverter());

                        object val = ser.Deserialize(jreader, type);
                        return val;
                    });

            return task;
        }

        public override Task WriteToStreamAsync(
            Type type, object value, Stream stream, HttpContent content, TransportContext transportContext)
        {
            Task task = Task.Factory.StartNew(
                () =>
                    {
                        var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, };

                        string json = JsonConvert.SerializeObject(
                            value, Formatting.Indented, new JsonConverter[1] { new IsoDateTimeConverter() });

                        byte[] buf = Encoding.Default.GetBytes(json);
                        stream.Write(buf, 0, buf.Length);
                        stream.Flush();
                    });

            return task;
        }
    }
}