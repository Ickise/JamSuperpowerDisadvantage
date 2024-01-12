using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LabScene : MonoBehaviour
{
    [SerializeField] private RecipeController _recipeController;

    [SerializeField] private GameObject[] listToDestroy;
    
    [SerializeField] private GameObject[] listToKeep;

    [SerializeField] private GameObject positionOfRecipe;

    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;

    [SerializeField] private Sprite labBackgroundSprite;

    [SerializeField] private TransitionToLab _transitionToLab;
    
    private GameObject objectToDontDisable;

    public bool canFade;

    private void Start()
    {
        InputReader._instance.onContinueEvent.AddListener(NextScene);
    }

    private void Update()
    {
        if (_transitionToLab.canChangeScene)
        {
            DoMove();
        }
    }

    private void DoMove()
    {
        InputReader._instance.onContinueEvent.RemoveListener(NextScene);

        objectToDontDisable.transform.position = positionOfRecipe.transform.position;

        objectToDontDisable.transform.localScale = positionOfRecipe.transform.localScale;

        backgroundSpriteRenderer.sprite = labBackgroundSprite;
        
        if (objectToDontDisable.transform.position == positionOfRecipe.transform.position)
        {
            objectToDontDisable.AddComponent<Recipe>();

            _transitionToLab.canChangeScene = false;
        }
    }

    public void NextScene()
    {
        if (_recipeController.hitRecipeObject != null)
        {
            canFade = true;
            
            objectToDontDisable = _recipeController.hitRecipeObject.gameObject;

            foreach (var gameObject in listToDestroy)
            {
                Destroy(gameObject);
            }

            foreach (var gameObject in listToKeep)
            {
                gameObject.SetActive(false);
                objectToDontDisable.SetActive(true);
                Destroy(objectToDontDisable.GetComponent<Recipe>());

                _recipeController.hitRecipeObject = null;
            }
        }
    }
}