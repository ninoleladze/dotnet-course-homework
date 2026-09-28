public class Counter
{
    private int count;

    public int Count
    {
        get { return count; }
    }

    public void Increment()
    {
        count++;
    }

    public void Decrement()
    {
        if (count > 0)
            count--;
    }

    public void Reset()
    {
        count = 0;
    }
}