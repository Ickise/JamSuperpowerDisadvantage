using TMPro;
using UnityEngine;

public class RecipeModel : MonoBehaviour
{
    [SerializeField] private Vector3 newScale = new Vector3(2, 2, 2);

    [SerializeField] private TextMeshProUGUI textToContinue;
    
    [SerializeField] private Camera cam;

    [SerializeField] private RecipeController _recipeController;

    [SerializeField] private Recipe hitObject;
    
    private RaycastHit2D hit2D;
    
    private float timeToLerp;
    
    private void Start()
    {
        InputReader._instance.onZoomEvent.AddListener(OnClick);
    }

    private void Update()
    {
        if (_recipeController.hitRecipeObject != null && _recipeController.hitRecipeObject.canZoom)
        {
            timeToLerp += 0.01f * Time.deltaTime;
            
            DontHighlightObject();
            MoveAndZoom();
        }
        else
        {
            HighlightObject();
        }
    }

    private void MoveAndZoom()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        Vector3 centerPosition = cam.ScreenToWorldPoint(screenCenter);

        if (textToContinue != null) textToContinue.gameObject.SetActive(true);

        _recipeController.hitRecipeObject.gameObject.transform.position = new Vector2(
            Mathf.Lerp(_recipeController.hitRecipeObject.gameObject.transform.position.x, centerPosition.x, timeToLerp),
            Mathf.Lerp(_recipeController.hitRecipeObject.gameObject.transform.position.y, centerPosition.y,
                timeToLerp));

        _recipeController.hitRecipeObject.gameObject.transform.localScale = new Vector2(
            Mathf.Lerp(_recipeController.hitRecipeObject.gameObject.transform.localScale.x, newScale.x,
                timeToLerp),
            Mathf.Lerp(_recipeController.hitRecipeObject.gameObject.transform.localScale.y, newScale.y,
                timeToLerp));
    }

    private void HighlightObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        hit2D = Physics2D.Raycast(ray.origin, ray.direction);
        
        if (hit2D.collider != null)
        {
            hitObject = hit2D.collider.gameObject.GetComponent<Recipe>();
            if (hitObject != null)
            {
                hitObject.paperColor = hitObject.spriteRendererRecipe.color; 
                hitObject.paperColor.a = 0.5f; 
                hitObject.textColor.a = 0.5f; 
                hitObject.textOfRecipe.color = hitObject.textColor; 
                hitObject.spriteRendererRecipe.color = hitObject.paperColor;
            }
        }
        else
        {
            DontHighlightObject();
        }
    }

    private void DontHighlightObject()
    {
        if (hitObject != null)
        {
             hitObject.paperColor.a = 1f;
             hitObject.textColor.a = 1f; 
             hitObject.textOfRecipe.color = hitObject.textColor;
             hitObject.spriteRendererRecipe.color = hitObject.paperColor;
             hitObject = null;
        }
    }

    private void OnClick()
    {
        if (textToContinue != null) textToContinue.gameObject.SetActive(false);
        timeToLerp = 0;
    }
}