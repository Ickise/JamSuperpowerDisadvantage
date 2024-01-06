using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Dialogue", order = 1)]
public class DialogueData : ScriptableObject
{
    [TextArea(3, 10)]
    public string dialogueLines;
    
    public RecipeData goodRecipe;
}