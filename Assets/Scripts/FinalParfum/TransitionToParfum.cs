using UnityEngine;

public class TransitionToParfum : MonoBehaviour
{
  [SerializeField] private GameObject animation;
  [SerializeField] private GameObject textToContinue;
  [SerializeField] private GameObject enjoyCustomer;
  [SerializeField] private GameObject sadCustomer;
 
  [SerializeField] private GameObject[] listToDisable;
  [SerializeField] private GameObject[] listToDisableAfterClick;
  [SerializeField] private GameObject[] listToEnable;

  [SerializeField] private SpriteRenderer[] outfit;
  
  [SerializeField] private SpriteRenderer backgroundSpriteRenderer;

  [SerializeField] private Sprite saloonSprite;
  
  [SerializeField] private AddRecipe _addRecipe;
  [SerializeField] private Model _model;
  
  private void Start()
  {
    InputReader._instance.onZoomEvent.AddListener(OnClick);
  }

  public void LaunchAnimation()
  {
    foreach (var gameObject in listToDisable)
    {
      gameObject.SetActive(false);
    }
    
    animation.SetActive(true);
    textToContinue.SetActive(true);
  }

  private void OnClick()
  {
    foreach (var gameObject in listToEnable)
    {
      gameObject.SetActive(true);
    }
    
    foreach (var gameObject in listToDisableAfterClick)
    {
      gameObject.SetActive(false);
    }
    backgroundSpriteRenderer.sprite = saloonSprite;

    if (_addRecipe.isGoodRecipe)
    {
      enjoyCustomer.SetActive(true);

      for (int i = 0; i < _model.recipeToChoose.finalOutfit.Length; i++)
      {
        outfit[i].sprite = _model.recipeToChoose.finalOutfit[i];
      }
    }
    else
    {
      sadCustomer.SetActive(true);
    }
  }
}
