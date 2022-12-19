using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Text;

#if NET48
using System.Collections.Generic;
#endif

#nullable enable

namespace MyOpCodeTable.Shared
{
    public static partial class JsonExtensions
    {
        public static Task<T> DeserializeAsync<T>(this string data, JsonSerializerSettings settings = null)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            return stream.DeserializeAsync<T>(settings);
        }

        public static Task<T> DeserializeAsync<T>(this Stream stream, JsonSerializerSettings settings = null)
        {
            return Task.Run(() =>
            {
                using (stream)
                using (var streamReader = new StreamReader(stream))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var serializer = settings == null ? JsonSerializer.CreateDefault() : JsonSerializer.Create(settings);
                    return serializer.Deserialize<T>(jsonReader);
                }
            });
        }

        public static async Task<string> SerializeAsync<T>(this T instance, JsonSerializerSettings settings = null)
        {
            using (var stream = new MemoryStream())
            {
                await instance.SerializeAsync(stream, settings).ConfigureAwait(false);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static Task SerializeAsync<T>(this T instance, Stream toStream, JsonSerializerSettings settings = null)
        {
            return Task.Run(() =>
            {
                using (var streamWriter = new StreamWriter(toStream))
                {
                    var serializer = settings == null ? JsonSerializer.CreateDefault() : JsonSerializer.Create(settings);
                    serializer.Serialize(streamWriter, instance);
                }
            });
        }
    }
}
