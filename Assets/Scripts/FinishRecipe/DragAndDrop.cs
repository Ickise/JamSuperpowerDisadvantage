using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private float mouseDragSpeed = 0.1f;

    [SerializeField] private Ingredients hitIngredient;
    [SerializeField] private Ingredients hitIngredientToHighlight;


    private Vector3 velocity = Vector3.zero;

    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    private void Start()
    {
        InputReader._instance.onDragEvent.AddListener(MousePressed);
        InputReader._instance.onDropEvent.AddListener(MouseReleased);
    }
    
    private void MousePressed()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit2D.collider != null && hit2D.collider.gameObject.CompareTag("Drag"))
        {
            hitIngredient = hit2D.collider.gameObject.GetComponent<Ingredients>();
            hitIngredient.canDrag = true;
            StartCoroutine(DragUpdate(hitIngredient.gameObject));
        }
    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initialDistance = Vector3.Distance(clickedObject.transform.position, Camera.main.transform.position);

        while (Input.mousePosition != Vector3.zero && hitIngredient != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (hitIngredient.canDrag)
            {
                hitIngredient.spriteRendererRecipe.sortingOrder = 6;
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position,
                    ray.GetPoint(initialDistance), ref velocity, mouseDragSpeed);
                yield return waitForFixedUpdate;
            }
        }
    }

    private void MouseReleased()
    {
        if (hitIngredient != null)
        {
            hitIngredient.spriteRendererRecipe.sortingOrder = 1;
            hitIngredient.canDrag = false;
            hitIngredient.transform.position = hitIngredient.originalPosition;
            hitIngredient = null;
        }
    }

    private void HighlightObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit2D.collider != null)
        {
            hitIngredientToHighlight = hit2D.collider.gameObject.GetComponent<Ingredients>();

            if (hitIngredientToHighlight != null && !hitIngredientToHighlight.canDrag)
            {
                hitIngredientToHighlight.paperColor = hitIngredientToHighlight.spriteRendererRecipe.color;
                hitIngredientToHighlight.paperColor.a = 0.5f;
                hitIngredientToHighlight.spriteRendererRecipe.color = hitIngredientToHighlight.paperColor;
            }
        }
        else
        {
            DontHighlightObject();
        }
    }

    private void DontHighlightObject()
    {
        if (hitIngredientToHighlight != null)
        {
            hitIngredientToHighlight.paperColor.a = 1f;
            hitIngredientToHighlight.spriteRendererRecipe.color = hitIngredientToHighlight.paperColor;
            hitIngredientToHighlight = null;
        }
    }
}