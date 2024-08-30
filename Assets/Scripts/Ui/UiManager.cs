using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    InventoryUi _inventoryUi;
    public InventoryUi inventoryUi => _inventoryUi;


    CraftingUi _craftingUi;
    public CraftingUi craftingUi => _craftingUi;


    PlayerInputs _playerInputs;
    public PlayerInputs playerInputs => _playerInputs;

    public EventSystem eventSystem;

    public UnityEvent successCraft;
    public UnityEvent failureCraft;
    private void Awake()
    {
        instance = this;
        eventSystem = FindObjectOfType<EventSystem>();
        _inventoryUi = GetComponent<InventoryUi>();
        _craftingUi = GetComponent<CraftingUi>();
        _playerInputs = FindAnyObjectByType<PlayerInputs>();

    }
    private void OnEnable()
    {
        _playerInputs.onInventory += inventoryUi.Toggler;
        _playerInputs.onDrop += inventoryUi.DropItem;

        _playerInputs.onCraft += craftingUi.Toggler;
        _playerInputs.onTryCraft += craftingUi.TryCraft;

    }
    private void OnDisable()
    {
        _playerInputs.onInventory -= inventoryUi.Toggler;
        _playerInputs.onDrop -= inventoryUi.DropItem;

        _playerInputs.onCraft -= craftingUi.Toggler;
        _playerInputs.onTryCraft -= craftingUi.TryCraft;
    }
}
