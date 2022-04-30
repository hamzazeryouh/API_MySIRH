using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API_MySIRH.Helpers
{
    public static class MapperExtensions
    {
        public static T ResolveJson<T>(this JObject jobj, string target)
        {
            return JsonConvert.DeserializeObject<T>(jobj.SelectToken(target).ToString());
        }
    }
}
