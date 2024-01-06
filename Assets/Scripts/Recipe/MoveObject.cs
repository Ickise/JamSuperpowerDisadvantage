using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private CameraRaycaster _cameraRaycaster;
    
    private Vector2 originalPosition;
    
    private Vector2 originalScale;
    
    private void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
        
        InputReader._instance.onZoomEvent.AddListener(OnZoomPerformed);
    }

    private void Update()
    {
        if (_cameraRaycaster.objectHit == gameObject)
        {
            MoveAndZoom();
        }
    }

    private void MoveAndZoom()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        
        Vector2 centerPosition = _cameraRaycaster.cam.ScreenToWorldPoint(screenCenter);
        
        transform.position = centerPosition;
        transform.localScale = new Vector3(2, 2, 2);
    }

    private void ReturnToOriginalPosition()
    { 
        transform.position = originalPosition;
        transform.localScale = originalScale;
        
        _cameraRaycaster.objectHit = null;
    }

    private void OnZoomPerformed()
    {
        ReturnToOriginalPosition();
    }
}
