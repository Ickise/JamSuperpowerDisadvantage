using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Model : MonoBehaviour
{
    [Header("À set up")]
    
    [SerializeField] private Controller _controller;
    [SerializeField] private View _view;
    
    [SerializeField] private CustomerData[] listOfCustomer;
    
    [SerializeField] private DialogueData[] listOfDialogue;
    
    [SerializeField] private RecipeData[] listOfRecipe;
    
    [Header("Ne pas set up")]
    
    public List<RecipeData> listOfChoosenRecipe = new List<RecipeData>();

    public DialogueData choosenDialogue;
    
    public CustomerData choosenCustomer;

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
        
        listOfChoosenRecipe.Clear();
        
        listOfChoosenRecipe.Add(choosenRecipe);
        
        for (int i = 0; i < 2; i++)
        {
            RecipeData recipe = null;
            
            while (recipe == null)
            {
                RecipeData randomRecipe = listOfRecipe[Random.Range(0, listOfRecipe.Length)];
                
                if (randomRecipe != choosenRecipe && listOfChoosenRecipe.Contains(randomRecipe) == false)
                {
                    recipe = randomRecipe;
                }
            }
            listOfChoosenRecipe.Add(recipe);
            Shuffle(listOfChoosenRecipe);
        }
    }
    
    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1) 
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
