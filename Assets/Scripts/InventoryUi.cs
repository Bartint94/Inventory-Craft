using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public static InventoryUi instance;
    public SlotUi[] slots;
    public List<ItemScriptable> items = new List<ItemScriptable>();
    public List<ItemScriptable> tempItems = new List<ItemScriptable>();

    [SerializeField] GameObject background;

    PlayerInputs _playerInputs;
    public PlayerInputs playerInputs => _playerInputs;


    bool isActive;
    private void Awake()
    {
        instance = this;
        slots = GetComponentsInChildren<SlotUi>(true);
        _playerInputs = FindAnyObjectByType<PlayerInputs>();
    }
    private void Start()
    {
        CloseInventory();
    }
    private void OnEnable()
    {
        _playerInputs.isHud += Toggler;
    }
    private void OnDisable()
    {
        _playerInputs.isHud -= Toggler;  
    }

    void Toggler()
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
        background.SetActive(true);    

        foreach (var item in tempItems)
        {
            AddItem(item);
        }
        tempItems.Clear();
        isActive = true;
        slots[0].slotButton.Select();
    }
    void CloseInventory()
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
}
