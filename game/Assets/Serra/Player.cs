using System;
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

namespace Serra{ public class Player : MonoBehaviour{




[Header("Components")]
[SerializeField] CharacterController character_controller;
[SerializeField] Health health;
[SerializeField] Interactor interactor;
Action<InputAction.CallbackContext> 
  interact_handler,
  move_left_begin_handler,
  move_left_end_handler,
  move_right_begin_handler,
  move_right_end_handler,
  jump_begin_handler,
  jump_end_handler;





void Start(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap action_map){
        interact_handler          = ctx => interactor.interact();
        move_left_begin_handler   = ctx => character_controller.move_left_begin();
        move_left_end_handler     = ctx => character_controller.move_left_end();
        move_right_begin_handler  = ctx => character_controller.move_right_begin();
        move_right_end_handler    = ctx => character_controller.move_right_end();
        jump_begin_handler        = ctx => character_controller.jump_begin();
        jump_end_handler          = ctx => character_controller.jump_end();
        action_map.interact_event           += interact_handler;
        action_map.move_left_begin_event    += move_left_begin_handler;
        action_map.move_left_end_event      += move_left_end_handler;
        action_map.move_right_begin_event   += move_right_begin_handler;
        action_map.move_right_end_event     += move_right_end_handler;
        action_map.jump_start_event         += jump_begin_handler;
        action_map.jump_end_event           += jump_end_handler;
    }        
}

void OnDestroy(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap action_map){
        action_map.interact_event           -= interact_handler;
        action_map.move_left_begin_event    -= move_left_begin_handler;
        action_map.move_left_end_event      -= move_left_end_handler;
        action_map.move_right_begin_event   -= move_right_begin_handler;
        action_map.move_right_end_event     -= move_right_end_handler;
        action_map.jump_start_event         -= jump_begin_handler;
        action_map.jump_end_event           -= jump_end_handler;
    }
}




}}