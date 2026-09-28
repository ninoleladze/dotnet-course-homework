public class Temperature
{
    private double celsius;

    public double Celsius
    {
        get { return celsius; }
        set { celsius = value; }
    }

    public double Fahrenheit
    {
        get { return celsius * 9 / 5 + 32; }
    }
}