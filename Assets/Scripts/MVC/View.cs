using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private Controller _controller;
    [SerializeField] private Model _model;

    [SerializeField] private TextMeshProUGUI dialogueTextToRefresh;
   // [SerializeField] private TextMeshPro recipeTextToRefresh;
   // [SerializeField] private TextMeshPro firstBadRecipeTextToRefresh;
   // [SerializeField] private TextMeshPro secondBadRecipeTextToRefresh;
    
    [SerializeField] private TextMeshPro[] listOfRecipeTextToRefresh;
    
    [SerializeField] private SpriteRenderer customerToRefresh;

    private void Start()
    {
        RefreshDialogue();
        RefreshRecipe();
        RefreshCustomer();
    }

    public void RefreshDialogue()
    {
        dialogueTextToRefresh.text = "" + _model.choosenDialogue.dialogueLines;
    }

    public void RefreshRecipe()
    {
        for (int i = 0; i < listOfRecipeTextToRefresh.Length; i++)
        {
            listOfRecipeTextToRefresh[i].text = "" + _model.listOfChoosenRecipe[i].recipeInstructions;
        }
    }

    public void RefreshCustomer()
    {
        customerToRefresh.sprite = _model.choosenCustomer;
    }
}
