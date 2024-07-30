public class InventoryItem
{
    public string name;
    public int count;

    public InventoryItem(string name, int count)
    {
        this.name = name;
        this.count = count;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Count
    {
        get => count;
        set => count = value;
    }
}