using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    [Header("A set up")]
    
    [SerializeField] private Controller _controller;
    [SerializeField] private View _view;
    [SerializeField] private InputReader _inputReader;
    
    [SerializeField] private Sprite[] listOfCustomer;
    
    [SerializeField] private DialogueData[] listOfDialogue;
    
    [SerializeField] private RecipeData[] listOfRecipe;

    [SerializeField] private Camera mainCamera;
    
    [Header("Ne pas set up")]
    
    public List<RecipeData> listOfBadRecipe = new List<RecipeData>();

    public DialogueData choosenDialogue;
    
    public Sprite choosenCustomer;
    
    public RecipeData choosenRecipe;
    
    private void Awake()
    {
        ChooseDialogue();
        ChooseRecipe();
        ChooseCustomer();
    }

    public void ChooseDialogue()
    {
        choosenDialogue = listOfDialogue[Random.Range(0, listOfDialogue.Length)];
    }

    public void ChooseCustomer()
    {
        choosenCustomer = listOfCustomer[Random.Range(0, listOfCustomer.Length)];
    }

    public void ChooseRecipe()
    {
        choosenRecipe = choosenDialogue.goodRecipe;
        
        listOfBadRecipe.Clear();
        
        for (int i = 0; i < 2; i++)
        {
            RecipeData recipe = null;
            
            while (recipe == null)
            {
                RecipeData randomRecipe = listOfRecipe[Random.Range(0, listOfRecipe.Length)];
                
                if (randomRecipe != choosenRecipe && listOfBadRecipe.Contains(randomRecipe) == false)
                {
                    recipe = randomRecipe;
                }
            }
            listOfBadRecipe.Add(recipe);
        }
    }
}
