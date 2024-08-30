using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.EventSystems;

public class CraftingUi : MonoBehaviour
{
    [SerializeField] Transform listParent;
    [SerializeField] RecipesHolder recipeHolder;
    [SerializeField] CraftSlot slot;
    [SerializeField] GameObject backgroundCraft;
    [SerializeField] TextMeshProUGUI tryText;

    public CraftSlot[] slots;

    UiManager uiManager;

    bool isActive;
    bool isAvailable;

    private void Awake()
    {
        
    }
    private void Start()
    {
        uiManager = UiManager.instance;
        InitRecipes();
        slots = GetComponentsInChildren<CraftSlot>(true);   
    }
    private void Update()
    {
        if (!isActive)  return; 
        if (!isAvailable) return;

        uiManager.playerInputs.CraftInput();
    }
    public void Toggler()
    {
        if(isActive)
        {
            CloseCraft();
        }
        else
        {
            uiManager.inventoryUi.CloseInventory();
            OpenCraft();
        }
    }
    void OpenCraft()
    {
        isActive = true;
        backgroundCraft.SetActive(true);
        CheckAvailable();
    }
    public void CloseCraft()
    {
        isActive = false;
        backgroundCraft.SetActive(false);
    }
    void InitRecipes()
    {
        for (int i = 0; i < recipeHolder.recipes.Count; i++) 
        {
            var slotSpawn = Instantiate(slot, listParent);

            slotSpawn.InitSlot(recipeHolder.recipes[i]);
        }
    }
    void CheckAvailable()
    {
        isAvailable = false;

        foreach (var slot in slots)
        {
            if (slot.slotButton.interactable)
            {
                slot.slotButton.Select();
                tryText.gameObject.SetActive(true);
                isAvailable = true;
            }
        }

        if(!isAvailable)
        {
            tryText.gameObject.SetActive(false);
        }
    }

    public void TryCraft()
    {
        var eventSystem = uiManager.eventSystem;


        foreach (var slot in slots)
        {
            if (eventSystem.currentSelectedGameObject == slot.slotButton.gameObject)
            {

                foreach(var material in slot._recipe.requiredMaterials)
                {
                    for(int i = 0; i < material.quantity; i++)
                    {
                        uiManager.inventoryUi.RemoveItem(material.material);
                    }

                }

                if(ChanceCalculation(slot._recipe))
                {
                    uiManager.inventoryUi.CollectItem(slot._recipe.resultItem);
                }
            }
        }
        

    }
    bool ChanceCalculation(Recipe recipe)
    {
        var rand = Random.Range(0f, 100f);
        if(rand > recipe.craftChance)
        {
            Debug.Log(rand.ToString());
            return false;
        }
        else
        {
            Debug.Log(rand.ToString());
            return true;
        }
    }


}
