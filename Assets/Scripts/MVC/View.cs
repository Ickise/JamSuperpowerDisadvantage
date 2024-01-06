using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private Controller _controller;
    [SerializeField] private Model _model;

    [SerializeField] private TextMeshProUGUI dialogueTextToRefresh;
    [SerializeField] private TextMeshPro recipeTextToRefresh;
    [SerializeField] private TextMeshPro firstBadRecipeTextToRefresh;
    [SerializeField] private TextMeshPro secondBadRecipeTextToRefresh;
    
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
        recipeTextToRefresh.text = "" + _model.choosenRecipe.recipeInstructions;
        
        firstBadRecipeTextToRefresh.text = "" + _model.listOfBadRecipe[0].recipeInstructions;
        
        secondBadRecipeTextToRefresh.text = "" + _model.listOfBadRecipe[1].recipeInstructions;
    }

    public void RefreshCustomer()
    {
        customerToRefresh.sprite = _model.choosenCustomer;
    }
}
