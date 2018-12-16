using System.Collections.Generic;

namespace SWAPIModel
{
    public interface IStarShipJsonResult
    {
        int Count { get; set; }
        string Next { get; set; }
        string Previous { get; set; }
        List<StarShip> Results { get; set; }
    }
}