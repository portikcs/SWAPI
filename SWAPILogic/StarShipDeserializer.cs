using SWAPIHelpers;
using SWAPIModel;

namespace SWAPILogic
{
    public class StarShipDeserializer : IStarShipDeserializer
    {
        private readonly IJsonConvertWrapper<StarShipJsonResult> _jsonConvertWrapper;

        public StarShipDeserializer(IJsonConvertWrapper<StarShipJsonResult> jsonConvertWrapper)
        {
            _jsonConvertWrapper = jsonConvertWrapper;
        }

        public IStarShipJsonResult DeserializeStarShips(string json)
        {
            return _jsonConvertWrapper.Deserialize(json);
        }
    }
}
