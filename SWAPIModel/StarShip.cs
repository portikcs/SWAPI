using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SWAPIModel
{
    public class StarShip : IStarShip
    {
        private const int YearDayCount = 365;
        private const int DayHourCount = 24;
        private const int MonthDayCount = 30;
        private const int WeekDayCount = 7;

        [JsonProperty("name")]
        public string Name {get; set;}
        [JsonProperty("model")]
        public string Model {get; set;}
        [JsonProperty("manufacturer")]
        public string Manufacturer {get; set;}
        [JsonProperty("cost_in_credits")]
        public string CostInCredits {get; set;}
        [JsonProperty("length")]
        public double Length {get; set;}
        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed {get; set;}
        [JsonProperty("crew")]
        public int Crew {get; set;}
        [JsonProperty("passengers")]
        public int Passengers {get; set;}
        [JsonProperty("cargo_capacity")]
        public string CargoCapacity {get; set;}
        [JsonProperty("consumables")]
        public string Consumables {get; set;}
        [JsonProperty("hyperdrive_rating")]
        public double HyperdriveRating {get; set;}
        [JsonProperty("MGLT")]
        public int Mglt {get; set;}
        [JsonProperty("starship_class")]
        public string StarshipClass {get; set;}
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
            if (distance == 0 || Mglt == 0 || consumables == 0) return -1;
            return distance / (consumables * Mglt);
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
                    value = value * YearDayCount * DayHourCount;
                    break;
                }
                case TimeParts.Month:
                case TimeParts.Months:
                {
                    value = value * MonthDayCount * DayHourCount;
                    break;
                }
                case TimeParts.Week:
                case TimeParts.Weeks:
                {
                    value = value * WeekDayCount * DayHourCount;
                    break;
                }
                case TimeParts.Day:
                case TimeParts.Days:
                {
                    value = value * DayHourCount;
                    break;
                }
            }

            return value;
        }

    }
}
