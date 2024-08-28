using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public SlotUi[] slots;
    public List<ItemScriptable> items = new List<ItemScriptable>();
    private void Awake()
    {
        slots = GetComponentsInChildren<SlotUi>();
        
    }
    void ClearSlots()
    {
        foreach (SlotUi slot in slots)
        {
            slot.InitItem(null);
        }
    }
    
    public void AddItem(ItemScriptable item)
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
                if(slot.currentItem)
                if (slot.currentItem.id == item.id)
                {
                    if (slot.quantity < item.slotCapacity)
                    {
                        free = slot;
                    }
                }
            }
        }

        if(free == null)
        {
            foreach (var slot in slots)
            {
                if(slot != null) 
                {
                    if(slot.currentItem=null)
                    {
                        free = slot;
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
}
