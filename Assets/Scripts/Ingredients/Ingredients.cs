using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public SpriteRenderer spriteRendererRecipe;
    
    public Color paperColor;
    
    public Vector3 originalPosition;

    public bool canDrag;

    public IngredientData _ingredientData; 
    
    private void Awake()
    {
        spriteRendererRecipe = GetComponent<SpriteRenderer>();

        originalPosition = transform.position;
        
        paperColor = spriteRendererRecipe.color;
    }
}