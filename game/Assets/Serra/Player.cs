using System;
using UnityEngine.InputSystem;
using UnityEngine;

namespace Serra{ public class Player : MonoBehaviour{




[Header("Components")]
[SerializeField] CharacterController character_controller;
[SerializeField] Health health;
[SerializeField] Interactor interactor;
[SerializeField] WeaponHolder weapon_holder;
[Header("variables")]
[SerializeField] float touch_damage;
[SerializeField] float touch_pushback;
Action<InputAction.CallbackContext> 
  interact_handler,
  move_left_begin_handler,
  move_left_end_handler,
  move_right_begin_handler,
  move_right_end_handler,
  jump_begin_handler,
  jump_end_handler,
  weapon_action_1_handler,
  weapon_action_2_handler,
  flip_left_handler,
  flip_right_handler;





void Start(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap action_map){
        interact_handler          = ctx => interactor.interact();
        move_left_begin_handler   = ctx => character_controller.move_left_begin();
        move_left_end_handler     = ctx => character_controller.move_left_end();
        move_right_begin_handler  = ctx => character_controller.move_right_begin();
        move_right_end_handler    = ctx => character_controller.move_right_end();
        jump_begin_handler        = ctx => character_controller.jump_begin();
        jump_end_handler          = ctx => character_controller.jump_end();
        weapon_action_1_handler   = ctx => weapon_holder.use_action_1();
        weapon_action_2_handler   = ctx => weapon_holder.use_action_2();
        flip_left_handler         = ctx => flip_player(true);
        flip_right_handler        = ctx => flip_player(false);
        action_map.interact_event           += interact_handler;
        action_map.move_left_begin_event    += move_left_begin_handler;
        action_map.move_left_begin_event    += flip_left_handler;
        action_map.move_left_end_event      += move_left_end_handler;
        action_map.move_right_begin_event   += move_right_begin_handler;
        action_map.move_right_begin_event   += flip_right_handler;
        action_map.move_right_end_event     += move_right_end_handler;
        action_map.jump_start_event         += jump_begin_handler;
        action_map.jump_end_event           += jump_end_handler;
        action_map.weapon_action_1_event    += weapon_action_1_handler;
        action_map.weapon_action_2_event    += weapon_action_2_handler;
    }        
}

public void flip_player(bool flag){
    gameObject.transform.rotation = (flag == true)
        ?Quaternion.Euler(0, 180, 0) 
        :Quaternion.Euler(0, 0, 0); 
}

void OnDestroy(){
    if (InputSystem.get_action_map("Gameplay") is GameplayActionMap action_map){
        action_map.interact_event           -= interact_handler;
        action_map.move_left_begin_event    -= move_left_begin_handler;
        action_map.move_left_begin_event    -= flip_left_handler;
        action_map.move_left_end_event      -= move_left_end_handler;
        action_map.move_right_begin_event   -= move_right_begin_handler;
        action_map.move_right_begin_event   -= flip_right_handler;
        action_map.move_right_end_event     -= move_right_end_handler;
        action_map.jump_start_event         -= jump_begin_handler;
        action_map.jump_end_event           -= jump_end_handler;
        action_map.weapon_action_1_event    -= weapon_action_1_handler;
        action_map.weapon_action_2_event    -= weapon_action_2_handler;
    }
}

void OnCollisionEnter2D(Collision2D other){
    if(other.gameObject.tag == "Enemy"){
        character_controller.apply_force(ForceMode2D.Impulse, ((transform.position - other.transform.position)+new Vector3(0,0.5f,0)).normalized * touch_pushback);
        health.damage(touch_damage);
    }
}




}}