using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCounter_New
{
    public static partial class JsonExtensions
    {
        public static IEnumerable<T> FromDelimitedJson<T>(TextReader reader, JsonSerializerSettings settings = null)
        {
            using (var jsonReader = new JsonTextReader(reader) { CloseInput = false, SupportMultipleContent = true })
            {
                var serializer = JsonSerializer.CreateDefault(settings);

                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType == JsonToken.EndArray)
                        continue;
                    yield return serializer.Deserialize<T>(jsonReader);
                }
            }
        }
    }
}
