using System.Collections.Generic;
using SWAPIModel;

namespace SWAPILogic
{
    public interface IStarShipDeserializer
    {
        IStarShipJsonResult DeserializeStarShips(string json);
    }
}