using SWAPIHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPILogic
{
    public class StopsCalculateLogic : IStopsCalculateLogic
    {
        private readonly IStarShipDeserializer _starShipDeserializer;
        private readonly IApiHandlerWrapper _apiHandlerWrapper;

        public StopsCalculateLogic(IStarShipDeserializer starShipDeserializer,
            IApiHandlerWrapper apiHandlerWrapper)
        {
            _starShipDeserializer = starShipDeserializer;
            _apiHandlerWrapper = apiHandlerWrapper;
        }

        public async Task<List<string>> CalculateStops(int distance, string url)
        {
            var result = new List<string>();
            var json =  await _apiHandlerWrapper.GetApiCallResultAsync(url);
            if(string.IsNullOrWhiteSpace(json)) return result;
            var ships = _starShipDeserializer.DeserializeStarShips(json);
            if(ships?.Results == null || !ships.Results.Any()) return result;
            foreach (var ship in ships.Results) result.Add($"{ship.Name}:{ship.CountStops(distance)}");
            return result;
        }
    }
}