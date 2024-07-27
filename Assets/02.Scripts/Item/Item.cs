
[System.Serializable]
public class Item
{
    public string name;
    public int maxCount;

    public Item(string name, int maxCount)
    {
        this.name = name;
        this.maxCount = maxCount;
    }
}
