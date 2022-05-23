using System.Text.Json;

namespace GeneticAlgo.Core.SharedModels;
public class Configuration
{
    private static Configuration? instance;
    private static readonly string pathToConfiguration = "..\\..\\..\\..\\configs\\gen-algo-config-example.json";
    public int Dt { get; set; }
    public double FMax { get; set; }
    public double Eps { get; set; }
    public List<BarrierCircle> Circles { get; set; } = new();

    public static Configuration GetInstance()
    {
        if (instance == null)
        {
            var jsonString = File.ReadAllText(pathToConfiguration);
            instance = JsonSerializer.Deserialize<Configuration>(jsonString);
            if (instance == null)
            {
                throw new Exception("Cannot open configuration file.");
            }
        }
        return instance;
    }
}