using TMPro;
using UnityEngine;

public class Firstaid : MonoBehaviour
{
    public static Firstaid Instance;
    public TextMeshProUGUI countText;
    private const int MaxCount = 3;
    private int _count;
    
    private void Awake()
    {
        Instance = this;
    }
    
    // count를 증가시킬 수 있다면 return true
    public bool IncreaseCount()
    {
        if (_count + 1 <= MaxCount)
        {   
            _count++;
            countText.text = _count + "/" + MaxCount;
            return true;
        }
        return false;
    }
}
