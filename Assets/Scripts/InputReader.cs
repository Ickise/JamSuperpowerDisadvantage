using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class InputReader : MonoBehaviour
{
    public UnityEvent onZoomEvent = new UnityEvent();

    public static InputReader _instance; 
    private void Awake()
    {
        _instance = this;
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            onZoomEvent.Invoke();
        }
    }
}
