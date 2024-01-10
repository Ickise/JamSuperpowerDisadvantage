using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class View : MonoBehaviour
{
    [Header("À set up")]

    [SerializeField] private Controller _controller;
    [SerializeField] private Model _model;

    [SerializeField] private TextMeshProUGUI dialogueTextToRefresh;
    
    [SerializeField] private TextMeshPro[] listOfRecipeTextToRefresh;
    
    [SerializeField] private SpriteRenderer customerToRefresh;
    [SerializeField] private SpriteRenderer dialogueBoxToRefresh;

    [SerializeField] private GameObject[] elementsToDisable;
    [SerializeField] private GameObject[] recipeToEnable;
    
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
            recipeToEnable[i].SetActive(false);
        }
    }

    public void RefreshCustomer()
    {
        customerToRefresh.sprite = _model.choosenCustomer.customerRepresentation;
        dialogueBoxToRefresh.sprite = _model.choosenCustomer.dialogueBox;
    }

    public void EnableRecipeText()
    {
        for (int i = 0; i < listOfRecipeTextToRefresh.Length; i++)
        {
            recipeToEnable[i].SetActive(true);
            
            dialogueTextToRefresh.enabled = false;
            elementsToDisable[i].SetActive(false);
        }
    }
}
