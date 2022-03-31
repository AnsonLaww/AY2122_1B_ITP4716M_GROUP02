
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform ItemsParent;
    public GameObject InventoryUIObj;


    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;

        slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            InventoryUIObj.SetActive(!InventoryUIObj.activeSelf);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void UpdateUI()
    {
       for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.Items.Count)
            {
                slots[i].AddItem(inventory.Items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }


}
