using UnityEngine;

public class RecipeController : MonoBehaviour
{
    [SerializeField] private GameObject positionOfRecipe;

    public Camera cam;

    public Recipe hitRecipeObject;

    public Recipe oldHitRecipeObject;

    private RaycastHit2D hit2D;

    private Vector3 originalScale = new Vector3(1, 1, 1);

    
    private void Start()
    {
        InputReader._instance.onZoomEvent.AddListener(GetHitObjectOnClick);
    }

    private void Update()
    {
        if (oldHitRecipeObject == null)
        {
            return;
        }
        
        if (!oldHitRecipeObject.canZoom && oldHitRecipeObject != null)
        {
            ReturnToOriginalPosition();
        }
    }

    private void GetHitObjectOnClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        hit2D = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.GetComponent<Recipe>() == hitRecipeObject)
            {
                return;
            }
            
            if (oldHitRecipeObject != null && oldHitRecipeObject.canZoom)
            {
                oldHitRecipeObject.canZoom = false;
                hitRecipeObject.canZoom = false;
                ReturnToOriginalPosition();
            }

            hitRecipeObject = hit2D.collider.gameObject.GetComponent<Recipe>();

            hitRecipeObject.canZoom = true; 
            
        }
        else if (hitRecipeObject != null)
        {
            hitRecipeObject.canZoom = false;
        }
        oldHitRecipeObject = hitRecipeObject;
    }

    private void ReturnToOriginalPosition()
    {
        if (positionOfRecipe.activeSelf)
        {
            oldHitRecipeObject.transform.position = oldHitRecipeObject.originalPosition;
            oldHitRecipeObject.transform.localScale = positionOfRecipe.transform.localScale;
            hitRecipeObject = null;
        }
        else
        {
            oldHitRecipeObject.transform.position = oldHitRecipeObject.originalPosition;
            oldHitRecipeObject.transform.localScale = originalScale;
            hitRecipeObject = null;
        }
    }
}