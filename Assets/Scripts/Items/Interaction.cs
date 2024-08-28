using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] ItemScriptable item;
    [SerializeField] InventoryUi inventoryUi;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUi.AddItem(item);
        }
    }
}
