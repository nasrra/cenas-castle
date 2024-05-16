using System;
using UnityEngine;

namespace Serra {public class PlayerInteraction : Interactor{




void Start(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap actionMap){
      actionMap.interact_event += ctx => interact();
    }
}

void OnDestroy(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap actionMap){
      actionMap.interact_event += ctx => interact();
    }   
}




}}