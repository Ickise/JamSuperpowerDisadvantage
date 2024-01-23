using System.Collections.Generic;
using UnityEngine;

public class AddRecipe : MonoBehaviour
{
    [SerializeField] private Model _model;

    private IngredientData[] listOfGoodIngredients;

    [SerializeField] private List<IngredientData> listOfPlayerIngredients = new List<IngredientData>();

    [SerializeField] private List<Ingredients> listOfIngredientsToReset = new List<Ingredients>();

    private RaycastHit2D hit2D;

    public bool isGoodRecipe;

    private void Update()
    {
        RaycastToDetectIngredient();
    }

    public void IngredientToRecipe()
    {
        listOfGoodIngredients = _model.recipeToChoose.listOfGoodIngredient;

        isGoodRecipe = IsGoodRecipe(listOfGoodIngredients, listOfPlayerIngredients.ToArray());

        if (isGoodRecipe)
        {
            //faire la transition avec le atchoum
        }

        if (!isGoodRecipe)
        {
            // faire la transition avec le atchoum
        }
    }

    public void Reset()
    {
        foreach (var ingredients in listOfIngredientsToReset)
        {
            ingredients.gameObject.SetActive(true);
        }

        listOfIngredientsToReset = null;
        listOfPlayerIngredients = null;

        listOfIngredientsToReset = new List<Ingredients>();
        listOfPlayerIngredients = new List<IngredientData>();
    }

    private bool IsGoodRecipe(IngredientData[] goodList, IngredientData[] playerList)
    {
        if (playerList.Length != goodList.Length)
        {
            return false;
        }

        for (int i = 0; i < goodList.Length; i++)
        {
            if (playerList[i] != goodList[i])
            {
                return false;
            }
        }

        return true;
    }

    private void RaycastToDetectIngredient()
    {
        hit2D = Physics2D.Raycast(transform.position, Vector2.zero);

        if (hit2D.collider != null)
        {
            Ingredients detectedObject = hit2D.collider.gameObject.GetComponent<Ingredients>();

            if (detectedObject != null)
            {
                listOfPlayerIngredients.Add(detectedObject._ingredientData);
                listOfIngredientsToReset.Add(detectedObject);
                detectedObject.gameObject.SetActive(false);
            }
        }
    }
}