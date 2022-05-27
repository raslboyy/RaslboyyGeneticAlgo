using System.Text.Json;

namespace GeneticAlgo.Core.SharedModels;
public class Configuration
{
    private static Configuration? instance;
    private static readonly string pathToConfiguration = "C:\\Users\\kWX1136994\\Desktop\\tp\\RaslboyyGeneticAlgo\\configs\\gen-algo-config-1.json";
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