using Unity.VisualScripting;
using UnityEngine;

namespace Serra{ public class Player : MonoBehaviour{

    [Header("Components")]
    [SerializeField] Interactor interactor;   

    void Start(){
        if (InputSystem.get_action_map("Gameplay") is GameplayActionMap actionMap){
          actionMap.interact_event += ctx => interactor.interact();
        }        
    }

    void OnDestroy(){
        if (InputSystem.get_action_map("Gameplay") is GameplayActionMap actionMap){
          actionMap.interact_event -= ctx => interactor.interact();
        }        
    }

}}