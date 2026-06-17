using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string url =
            "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=59.4370&lon=24.7536";

        using HttpClient client = new HttpClient();

        // Yr.no nõuab User-Agent päist
        client.DefaultRequestHeaders.Add(
            "User-Agent",
            "TallinnWeatherApp/1.0"
        );

        try
        {
            string json = await client.GetStringAsync(url);

            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement timeseries =
                document.RootElement
                        .GetProperty("properties")
                        .GetProperty("timeseries");

            Console.WriteLine("Tallinna ilmaennustus:");
            Console.WriteLine();

            // Näitab järgmise 10 tunni temperatuuri
            for (int i = 0; i < 10; i++)
            {
                JsonElement item = timeseries[i];

                string time = item
                    .GetProperty("time")
                    .GetString();

                double temperature = item
                    .GetProperty("data")
                    .GetProperty("instant")
                    .GetProperty("details")
                    .GetProperty("air_temperature")
                    .GetDouble();

                Console.WriteLine($"{time} {temperature}C");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Viga andmete lugemisel:");
            Console.WriteLine(ex.Message);
        }
    }
}
