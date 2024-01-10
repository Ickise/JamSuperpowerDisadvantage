using TMPro;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public SpriteRenderer spriteRendererRecipe;
    
    public TextMeshPro textOfRecipe;
    
    public Color paperColor;

    public Color textColor;

    public Vector3 originalPosition;
    
    public bool canZoom;
    
    private void Awake()
    {
        spriteRendererRecipe = GetComponent<SpriteRenderer>();

        textOfRecipe = GetComponentInChildren<TextMeshPro>();
        
        originalPosition = transform.position;
        
        paperColor = spriteRendererRecipe.color;
        
        textColor = textOfRecipe.color;
    }
}
