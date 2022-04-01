
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    Item item;

    public Image Icon;

    public void AddItem(Item newItem)
    {
        item = newItem;

        Icon.sprite = item.icon;
        Icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        Icon.sprite = null;
        Icon.enabled = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }


}

