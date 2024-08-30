using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public ItemScriptable resultItem;
    public CraftMaterials[] requiredMaterials;
    public float craftChance;

    
}

