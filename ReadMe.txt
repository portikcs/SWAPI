The application SWAPIConsole was created to download all the SW star ships from an API available here: https://swapi.co/ and based on the distance provided as an argument in MGLT, to calculate how many stops are required for a given star ship to travel the distance.
The application requires to access the given API, to be able to download the star ships.
The result is displayed in a list, the items of the list are in the following format
{star ship name}: {number of stops required}
To run the application, please follow the steps above:
1. Open a command prompt application. (cmd)
2. Navigate to build output folder, for example for example: ..\SWAPIConsole\bin\Debug\netcoreapp2.1
3. The program can be started two ways without any argument, in this case it will prompt to provide the distance
4. Or you can start it by providing the distance as argument
5. The result is displayed on screen, getting the raw data from https://swapi.co/api/starships/.
