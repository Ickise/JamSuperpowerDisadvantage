using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Ingredient", order = 1)]
public class IngredientData : ScriptableObject
{
    public string nameOfIngredient;
    
    public Sprite ingredientRepresentation;
}