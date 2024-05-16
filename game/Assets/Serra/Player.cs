using Unity.VisualScripting;
using UnityEngine;

namespace Serra{ public class Player : MonoBehaviour{




[Header("Components")]
[SerializeField] CharacterController character_controller;
[SerializeField] Interactor interactor;




void Start(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap action_map){
      action_map.interact_event           += ctx => interactor.interact();
      action_map.move_left_begin_event    += ctx => character_controller.move_left_begin(); 
      action_map.move_left_end_event      += ctx => character_controller.move_left_end();
      action_map.move_right_begin_event   += ctx => character_controller.move_right_begin(); 
      action_map.move_right_end_event     += ctx => character_controller.move_right_end();
      action_map.jump_start_event         += ctx => character_controller.jump_begin();
      action_map.jump_end_event           += ctx => character_controller.jump_end();
    }        
}

void OnDestroy(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap action_map){
      action_map.interact_event           -= ctx => interactor.interact();
      action_map.move_left_begin_event    -= ctx => character_controller.move_left_begin(); 
      action_map.move_left_end_event      -= ctx => character_controller.move_left_end();
      action_map.move_right_begin_event   -= ctx => character_controller.move_right_begin(); 
      action_map.move_right_end_event     -= ctx => character_controller.move_right_end();
      action_map.jump_start_event         -= ctx => character_controller.jump_begin();
      action_map.jump_end_event           -= ctx => character_controller.jump_end();
    }        
}




}}