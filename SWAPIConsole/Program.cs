using Microsoft.Extensions.Configuration;
using SWAPIHelpers;
using SWAPILogic;
using SWAPIModel;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SWAPIConsole
{
    class Program
    {
        protected Program()
        {
        }

        private const string ConfigPath = "appsettings.json";

        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 1)
                {
                    Console.WriteLine("The argument count is not valid, please use it with a single argument, that is containing the distance in 'MGLT'!");
                }
                else
                {
                    string stringDistance;
                    if (args.Length == 0) 
                    {
                        Console.WriteLine("Please provide distance in MGLT :");
                        stringDistance = Console.ReadLine();
                    }
                    else  stringDistance = args[0];
                    

                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile(ConfigPath, optional: true, reloadOnChange: true);

                    var configuration = builder.Build();

                    var url = configuration.GetSection("url").Value;

                    if (!int.TryParse(stringDistance, out var distance))
                    {
                        Console.WriteLine($"Could not convert the given argument {args[0]} to integer! ");
                    }
                    else
                    {
                        var calculate = new StopsCalculateLogic(
                            new StarShipDeserializer(new JsonConvertWrapper<StarShipJsonResult>()),
                            new ApiHandlerWrapper());
                        var result = Task.Factory.StartNew(()=> calculate.CalculateStops(distance, url));
                        result.Wait();
                        foreach (var item in result.Result.Result)  Console.WriteLine(item); 
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred, with message: {e.Message} and stack: {e.StackTrace}");
            }

            Console.WriteLine("Press any key to exit ....");
            Console.ReadKey();
        }
    }
}
