using UnityEngine;

public class TransitionToLab : MonoBehaviour
{
    [SerializeField] private GameObject fader;

    [SerializeField] private LabScene _labScene;

    public bool canChangeScene;
    private void Update()
    {
        if (_labScene.canFade)
        {
            fader.gameObject.SetActive(true);
        }
    }

    public void DoTransition()
    {
        canChangeScene = true;
        _labScene.canFade = false;
    }

    public void DestroyObject()
    {
        Destroy(_labScene.gameObject);
        Destroy(gameObject);
    }
}
