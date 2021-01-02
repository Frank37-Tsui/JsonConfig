using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;

namespace JsonConfig
{
    public class JsonConfig
    {
        public string Json { get; private set; }
        private IDictionary<string, object> props;
        private string JsonFile;

        public JsonConfig(string jsonFile)
        {
            JsonFile = jsonFile;
            Json = File.Exists(jsonFile) ? File.ReadAllText(jsonFile) : "{}";
            props = JsonConvert.DeserializeObject<ExpandoObject>(Json, new ExpandoObjectConverter()) as IDictionary<string, Object>;
        }

        public ExpandoObject GetProperty(string propName)
        {
            dynamic prop;
            if (!props.TryGetValue(propName, out prop))
            {
                prop = new ExpandoObject();
                props.Add(propName, prop);
            }
            return prop;
        }

        public IDictionary<string, Object> Save()
        {
            var dir = Path.GetDirectoryName(JsonFile);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(JsonFile, JsonConvert.SerializeObject(props, Formatting.Indented));
            return props;
        }
    }
}
