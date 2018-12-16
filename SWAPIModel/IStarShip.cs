using System;
using System.Collections.Generic;

namespace SWAPIModel
{
    interface IStarShip
    {
        string Name { get; set; }

        string Model { get; set; }

        string Manufacturer { get; set; }

        string CostInCredits { get; set; }

        double Length { get; set; }

        string MaxAtmospheringSpeed { get; set; }

        int Crew { get; set; }

        int Passengers { get; set; }

        string CargoCapacity { get; set; }

        string Consumables { get; set; }

        double HyperdriveRating { get; set; }

        int Mglt { get; set; }

        string StarshipClass { get; set; }

        List<string> Pilots { get; set; }

        List<string> Films { get; set; }

        DateTime Created { get; set; }

        DateTime Edited { get; set; }

        string Url { get; set; }

        int CountStops(int distance);
    }
}
