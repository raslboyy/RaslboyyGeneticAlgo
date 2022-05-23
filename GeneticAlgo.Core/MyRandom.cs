namespace GeneticAlgo.Core;
internal class MyRandom : Random
{
    public static MyRandom? Instance { get; private set; }
    private MyRandom() : base(DateTime.Now.Second) { }
    public static MyRandom GetInstance()
    {
        if (Instance == null)
            Instance = new MyRandom();
        return Instance;
    }
}