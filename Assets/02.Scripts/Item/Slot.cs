using UnityEngine;
using UnityEngine.UI;

public class Slot
{
    private Item _item;
    private Image _itemImage;
    private Image _outlineImage;
    private Text _countText;
    private int _itemCount;

    public Item Item
    {
        get => _item;
        set => _item = value;
    }

    public int ItemCount => _itemCount;

    public Slot(Image itemImage, Image outlineImage, Text countText)
    {
        _itemImage = itemImage;
        _outlineImage = outlineImage;
        _countText = countText;
        _itemCount = 1;
    }

    // itemimage 부착
    public void AttachItemImage(Sprite sprite)
    {
        _itemImage.sprite = sprite;
    }
    
    // outlineImgage toggle
    public void ToggleOutline()
    {
        if (_outlineImage.enabled)
        {
            _outlineImage.enabled = false;
        }
        else
        {
            _outlineImage.enabled = true;
        }
    }
    
    
    // itemCount 조정 
    public void IncreaseCount()
    {
        _itemCount++;
        _countText.text = "X" + _itemCount;
    }
    
    // TODO 아이템 감소 후 0개가 되면 Slot 삭제해야함 
    public int DecreaseCount()
    {
        _itemCount--;
        if (_itemCount == 1) // ItemCountText 삭제 
        {
            _countText.text = null;
        }
        else if (_itemCount != 0)
        {
            _countText.text = "X" + _itemCount;
        }

        return _itemCount;
    }
}
