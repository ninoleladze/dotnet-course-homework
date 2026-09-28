public class Clock
{
    private int hours;
    private int minutes;

    public int Hours
    {
        get { return hours; }
        set
        {
            hours = ((value % 24) + 24) % 24;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            minutes = ((value % 60) + 60) % 60;
        }
    }

    public override string ToString()
    {
      
        return $"{Hours:D2}:{Minutes:D2}";
    }
}