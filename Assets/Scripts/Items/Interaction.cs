using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] ItemScriptable item;
    [SerializeField] GameObject pickupText;
    InventoryUi inventoryUi;
    GameObject instantiated;
    Camera cam;
    PlayerInputs playerInputs;
    private void Start()
    {
        inventoryUi = InventoryUi.instance;
        playerInputs = inventoryUi.playerInputs;
        cam = Camera.main;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerInputs input))
        {
            instantiated = Instantiate(pickupText,transform.position + Vector3.up * 1f, Quaternion.identity);
        }
    }
  

    private void OnTriggerExit(Collider other)
    {
        if (!instantiated) return;

        if(other.TryGetComponent(out PlayerInputs input))
        {
            Destroy(instantiated);
        }
    }
    private void LateUpdate()
    {
        if (!instantiated) return;
        if (playerInputs.pickup)
        {
            inventoryUi.CollectItem(item);
            Destroy(instantiated);  
            Destroy(gameObject);
        }

        instantiated.transform.LookAt(cam.transform);
    }
}
