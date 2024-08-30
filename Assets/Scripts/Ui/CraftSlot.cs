using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    [SerializeField] RawImage _image;
    [SerializeField] TextMeshProUGUI discription;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] Button _button; 
    public Button slotButton => _button;

    public Recipe _recipe;

    InventoryUi inventory;

    public List<ItemScriptable> debug;
    private void Start()
    {
    }
    private void OnEnable()
    {
        inventory = UiManager.instance.inventoryUi;
        CheckRequirements();
    }
    public void InitSlot(Recipe recipe)
    {
        _recipe = recipe;
        _image.texture = recipe.resultItem._texture;
        title.text = recipe.resultItem.name;
        discription.text = $"Required: ";
        foreach (var material in recipe.requiredMaterials)
        {
            discription.text += $"{material.material.name} {material.quantity}X\n"; 
        }
        discription.text += $"Craft chance = {recipe.craftChance}";
    }
   
    void CheckRequirements()
    {
        _button.interactable = false;

        foreach (var material in _recipe.requiredMaterials)
        {
            List<ItemScriptable> temp = new List<ItemScriptable>();


            for (int i = 0; i < inventory.items.Count; i++)
            {
                if (inventory.items[i].id == material.material.id)
                {
                    temp.Add(inventory.items[i]);

                  
                }
              
                if(i == inventory.items.Count - 1)
                {
                    if (temp.Count >= material.quantity)
                    {
                        _button.interactable = true;
                    }
                    else
                    {
                        _button.interactable = false;
                        return;
                    }


                }
            }

        }
    }


}
