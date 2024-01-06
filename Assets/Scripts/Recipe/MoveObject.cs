using Cinemachine.Utility;
using TMPro;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private CameraRaycaster _cameraRaycaster;
    
    [SerializeField] private Vector3 newScale = new Vector3(2,2, 2);

    [SerializeField] private TextMeshProUGUI textToContinue;

    private Vector3 originalPosition;
    
    private Vector3 originalScale = new Vector3(1,1, 1);
    
    private float timeToLerp;

    private bool canZoom;
    
    private void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;

        _cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        
        InputReader._instance.onZoomEvent.AddListener(OnZoomPerformed);
    }

    private void Update()
    {
        if (_cameraRaycaster.objectHit == gameObject)
        {
            canZoom = true;

            if (canZoom)
            {
                timeToLerp += 0.01f * Time.deltaTime;

                MoveAndZoom();
            }
        }
    }

    private void MoveAndZoom()
    {
        textToContinue.gameObject.SetActive(true);
        
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        
        Vector3 centerPosition = _cameraRaycaster.cam.ScreenToWorldPoint(screenCenter);
        
        if (centerPosition != gameObject.transform.position)
        {     
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, centerPosition.x,timeToLerp),
                Mathf.Lerp(transform.position.y, centerPosition.y,timeToLerp));
        
            transform.localScale = new Vector2(Mathf.Lerp( transform.localScale.x, newScale.x,timeToLerp),
                Mathf.Lerp( transform.localScale.y, newScale.y,timeToLerp));
        }
        canZoom = false;
    }

    private void ReturnToOriginalPosition()
    { 
        transform.position = originalPosition;
        transform.localScale = originalScale;
    }

    private void OnZoomPerformed()
    {
        if (!canZoom)
        {
            textToContinue.gameObject.SetActive(false);

            timeToLerp = 0;
            ReturnToOriginalPosition();
        }
    }
}
