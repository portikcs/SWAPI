using Newtonsoft.Json;

namespace SWAPIHelpers
{
    public class JsonConvertWrapper<T> : IJsonConvertWrapper<T>
    {
        public T Deserialize(string json)
        {
           return JsonConvert.DeserializeObject<T>(json);
        }

    }
}
