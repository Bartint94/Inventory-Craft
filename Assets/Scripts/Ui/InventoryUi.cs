using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUi : MonoBehaviour
{
    public SlotUi[] slots;
    public List<ItemScriptable> items = new List<ItemScriptable>();
    public List<ItemScriptable> tempItems = new List<ItemScriptable>();

    [SerializeField] GameObject background;

  

    bool isActive;

    UiManager uiManager;
    private void Awake()
    {
        slots = GetComponentsInChildren<SlotUi>(true);
    }
    private void Start()
    {
        uiManager = UiManager.instance;
        CloseInventory();
    }
    private void Update()
    {
        if (isActive)
        {
            uiManager.playerInputs.InventoryInput();
            
        }
    }


    public void Toggler()
    {
        if(isActive)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
    }
    void OpenInventory()
    {
        UiManager.instance.craftingUi.CloseCraft();
        background.SetActive(true);    

        foreach (var item in tempItems)
        {
            AddItem(item);
        }
        tempItems.Clear();
        isActive = true;
        slots[0].slotButton.Select();
    }
    public void CloseInventory()
    {
        background.SetActive(false);
        isActive = false;
    }

    public void CollectItem(ItemScriptable item)
    {
        if (isActive)
        {
            AddItem(item);
        }
        else
        {
            tempItems.Add(item);
        }
        items.Add(item);
    }
    void AddItem(ItemScriptable item)
    {
        var slot = FindFreeSlot(item);

        if (slot != null)
        {
            slot.InitItem(item);
        }
        
    }
    SlotUi FindFreeSlot(ItemScriptable item)
    {
        SlotUi free = null;
        foreach (var slot in slots)
        {
            if (slot != null)
            {
                if (slot.currentItem)
                    if (slot.currentItem.id == item.id)
                    {
                        if (slot.quantity < item.slotCapacity)
                        {
                            free = slot;
                        }
                    }
            }
        }

        if (free == null)
        {
            foreach (var slot in slots)
            {
                if(slot != null) 
                {
                    if(slot.currentItem == null)
                    {
                        free = slot;
                        break;
                    }
                }
            }
        }
        
        if(free == null)
        {
            Debug.Log("No Space");
        }
        return free;
    }

    public void RemoveItem(ItemScriptable item)
    {
        foreach(var slot in slots)
        {
            if (!slot.currentItem) return;

            if (slot.currentItem.id == item.id)
            {
                items.Remove(slot.currentItem);
                slot.UseItem();
            }
        }
    }

    public void DropItem()
    {
        var eventsystem = UiManager.instance.eventSystem;
        foreach(var slot in slots)
        {
            if (eventsystem.currentSelectedGameObject == slot.slotButton.gameObject)
            {
                if(slot.quantity <= 0)
                {
                    return;

                }
                else 
                {
                    items.Remove(slot.currentItem);
                    slot.DropItem();
                }
             
            }
        }
    }
}
