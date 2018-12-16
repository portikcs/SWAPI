using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWAPIModel
{
    interface IStarShip
    {
        string Name { get; set; }

        string Model { get; set; }

        string Manufacturer { get; set; }

        string Cost_in_credits { get; set; }

        double Length { get; set; }

        string Max_atmosphering_speed { get; set; }

        int Crew { get; set; }

        int Passengers { get; set; }

        string Cargo_capacity { get; set; }

        string Consumables { get; set; }

        double Hyperdrive_rating { get; set; }

        int MGLT { get; set; }

        string Starship_class { get; set; }

        List<string> Pilots { get; set; }

        List<string> Films { get; set; }

        DateTime Created { get; set; }

        DateTime Edited { get; set; }

        string Url { get; set; }

        int CountStops(int distance);
    }
}
