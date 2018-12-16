using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SWAPIModel
{
    public class StarShip : IStarShip
    {
        private const int yearDayCount = 365;
        private const int dayHourCount = 24;
        private const int monthDayCount = 30;
        private const int weekDayCount = 7;

        [JsonProperty("name")]
        public string Name {get; set;}
        [JsonProperty("model")]
        public string Model {get; set;}
        [JsonProperty("manufacturer")]
        public string Manufacturer {get; set;}
        [JsonProperty("cost_in_credits")]
        public string Cost_in_credits {get; set;}
        [JsonProperty("length")]
        public double Length {get; set;}
        [JsonProperty("max_atmosphering_speed")]
        public string Max_atmosphering_speed {get; set;}
        [JsonProperty("crew")]
        public int Crew {get; set;}
        [JsonProperty("passengers")]
        public int Passengers {get; set;}
        [JsonProperty("cargo_capacity")]
        public string Cargo_capacity {get; set;}
        [JsonProperty("consumables")]
        public string Consumables {get; set;}
        [JsonProperty("hyperdrive_rating")]
        public double Hyperdrive_rating {get; set;}
        [JsonProperty("MGLT")]
        public int MGLT {get; set;}
        [JsonProperty("starship_class")]
        public string Starship_class {get; set;}
        [JsonProperty("pilots")]
        public List<string> Pilots {get; set;}
        [JsonProperty("films")]
        public List<string> Films {get; set;}
        [JsonProperty("created")]
        public DateTime Created {get; set;}
        [JsonProperty("edited")]
        public DateTime Edited {get; set;}
        [JsonProperty("url")]
        public string Url {get; set;}

        public int CountStops(int distance)
        {
            var consumables = ConsumablesInHoursAsync(Consumables);
            if (distance == 0 || MGLT == 0 || consumables == 0) return 0;
            return distance / (consumables * MGLT);
        }

        private int ConsumablesInHoursAsync(string consumables)
        {
            var data = consumables.Split(' ');

            if (!int.TryParse(data[0], out var value)) return 0;

            switch (data[1].Trim().ToLower())
            {
                case TimeParts.Year :
                case TimeParts.Years:
                {
                    value = value * yearDayCount * dayHourCount;
                    break;
                }
                case TimeParts.Month:
                case TimeParts.Months:
                {
                    value = value * monthDayCount * dayHourCount;
                    break;
                }
                case TimeParts.Week:
                case TimeParts.Weeks:
                {
                    value = value * weekDayCount * dayHourCount;
                    break;
                }
                case TimeParts.Day:
                case TimeParts.Days:
                {
                    value = value * dayHourCount;
                    break;
                }
            }

            return value;
        }

    }
}
