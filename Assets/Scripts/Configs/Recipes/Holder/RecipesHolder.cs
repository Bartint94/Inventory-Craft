using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "RecipeHolder")]
public class RecipesHolder : ScriptableObject 
{
    public List<Recipe> recipes;
}
