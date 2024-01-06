using UnityEngine;

public class LabScene : MonoBehaviour
{
    [SerializeField] private CameraRaycaster _cameraRaycaster;

    [SerializeField] private GameObject[] listOfGameObject;
    
    [SerializeField] private GameObject positionOfRecipe;
    
    private float timeToLerp;
    
    private bool canMove;

    private GameObject objectToDontDisable;

    private void Start()
    {
        InputReader._instance.onContinueEvent.AddListener(NextScene);
    }

    private void Update()
    {
      DoMove();
    }

    private void DoMove()
    {
        if (canMove)
        {
            timeToLerp += 0.01f * Time.deltaTime;
            InputReader._instance.onContinueEvent.RemoveListener(NextScene);

            UpdateLerp(objectToDontDisable.transform,
                positionOfRecipe.transform, objectToDontDisable.transform, positionOfRecipe.transform);
            
            if (objectToDontDisable.transform.position == positionOfRecipe.transform.position)
            {
                canMove = false;
                
                objectToDontDisable.AddComponent<MoveObject>();
            }
        }
    }
    private void UpdateLerp(Transform oldPosition, Transform newPosition, Transform oldScale, Transform newScale)
    {
        oldPosition.position = new Vector2(
            Mathf.Lerp(oldPosition.position.x, newPosition.position.x, timeToLerp),
            Mathf.Lerp(oldPosition.position.y, newPosition.position.y, timeToLerp));
        
        oldScale.localScale = new Vector2(Mathf.Lerp( oldScale.localScale.x, newScale.localScale.x, timeToLerp),
            Mathf.Lerp( oldScale.localScale.y, newScale.localScale.y, timeToLerp));
    }

    public void NextScene()
    {
        if (_cameraRaycaster.objectHit != null)
        { 
            objectToDontDisable = _cameraRaycaster.objectHit;
            
            foreach (var gameObject in listOfGameObject)
            {
                gameObject.SetActive(false);
                objectToDontDisable.SetActive(true);
                Destroy(objectToDontDisable.GetComponent<MoveObject>());
                
                _cameraRaycaster.objectHit = null;
                canMove = true;
            }
        }
    }
}
