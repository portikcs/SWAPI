using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWAPILogic
{
    public interface IStopsCalculateLogic
    {
        Task<List<string>> CalculateStops(int distance, string url);
    }
}