using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    public Camera cam;

    public RaycastHit2D hit2D;

    public Recipe hitRecipeObject;
    
    private void Start()
    {
        InputReader._instance.onZoomEvent.AddListener(OnClickPerformed);
    }
    
    private void OnClickPerformed()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        hit2D = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit2D.collider != null)
        {
            hitRecipeObject = hit2D.collider.gameObject.GetComponent<Recipe>();
        }
        else
        {
            hitRecipeObject = null;
        }
    }
}