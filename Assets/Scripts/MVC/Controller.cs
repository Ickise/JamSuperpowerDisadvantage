using UnityEngine;
/// <summary>
/// Il reçoit les interactions du joueur et met à jour la data et met à jour la vue
/// </summary>
public class Controller : MonoBehaviour
{
    [SerializeField] private Model _model;
    
    [SerializeField] private View _view;

    [SerializeField] private InputReader _inputReader;
}
