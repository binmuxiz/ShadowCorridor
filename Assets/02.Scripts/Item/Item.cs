
public class Item
{
    private string name;
    private int count;
    private int maxCount;

    public Item(string name, int count, int maxCount)
    {
        this.name = name;
        this.count = count;
        this.maxCount = maxCount;
        
    }

    public int Count
    {
        get => count;
        set => this.count = value;
    }

    public int MaxCount
    {
        get => maxCount;
        set => this.maxCount = value;
    }
}
