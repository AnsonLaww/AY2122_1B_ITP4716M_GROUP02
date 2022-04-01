using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {

        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();

    public OnItemChanged OnItemChangedCallback;

    public int Space = 15;

    public List<Item> Items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(Items.Count >= Space)
            {
                Debug.Log("Not enough slot");
                return false;
            }
            Items.Add(item);

            if(OnItemChangedCallback != null)
            {
                OnItemChangedCallback.Invoke();
            }



        }
        return true;

    }


    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }

    }

}

