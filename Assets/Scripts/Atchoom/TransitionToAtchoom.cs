using UnityEngine;

public class TransitionToAtchoom : MonoBehaviour
{
    [SerializeField] private AddRecipe _addRecipe;

    [SerializeField] private GameObject blackScreen;
    
    private void Update()
    {
        if (_addRecipe.isGoodRecipe)
        {
            blackScreen.SetActive(true);
            //faire la transition 
        }
    }
}
