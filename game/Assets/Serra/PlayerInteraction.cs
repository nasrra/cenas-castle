using System;
using UnityEngine;

namespace Serra {public class PlayerInteraction : MonoBehaviour{
void Start(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap actionMap){
      actionMap.interact_event += ctx => interact();
    }
}

public void interact(){
    Debug.Log("interaction!");
}

void OnDestroy(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap actionMap){
      actionMap.interact_event += ctx => interact();
    }   
}

}}