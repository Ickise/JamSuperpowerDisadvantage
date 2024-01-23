using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Recipe", order = 1)]
public class RecipeData : ScriptableObject
{
    public string nameOfRecipe;
    
    [TextArea(3, 10)]
    public string recipeInstructions;
    
    public IngredientData[] listOfGoodIngredient;
    
    public Sprite[] finalOutfit;
}