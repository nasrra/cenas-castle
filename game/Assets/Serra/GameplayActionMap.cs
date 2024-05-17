using System;
using UnityEngine.InputSystem;

namespace Serra{public class GameplayActionMap : ActionMap{





public event Action<InputAction.CallbackContext> 
    interact_event, 
    move_left_begin_event, 
    move_left_end_event,
    move_right_begin_event,
    move_right_end_event,
    jump_start_event,
    jump_end_event,
    weapon_action_1_event,
    weapon_action_2_event;




public override void subscribe_to_events(PlayerInput input){
    input.actions["interact"].performed         += ctx => interact_event?.Invoke(ctx);
    input.actions["move_left"].performed        += ctx => move_left_begin_event?.Invoke(ctx);
    input.actions["move_left"].canceled         += ctx => move_left_end_event?.Invoke(ctx);
    input.actions["move_right"].performed       += ctx => move_right_begin_event?.Invoke(ctx);
    input.actions["move_right"].canceled        += ctx => move_right_end_event?.Invoke(ctx);
    input.actions["jump"].performed             += ctx => jump_start_event?.Invoke(ctx);
    input.actions["jump"].canceled              += ctx => jump_end_event?.Invoke(ctx);
    input.actions["weapon_action_1"].performed  += ctx => weapon_action_1_event?.Invoke(ctx);
    input.actions["weapon_action_2"].performed  += ctx => weapon_action_2_event?.Invoke(ctx);
}
public override void unsubscribe_to_events(PlayerInput input){
    input.actions["interact"].performed         -= ctx => interact_event?.Invoke(ctx);
    input.actions["move_left"].performed        -= ctx => move_left_begin_event?.Invoke(ctx);
    input.actions["move_left"].canceled         -= ctx => move_left_end_event?.Invoke(ctx);
    input.actions["move_right"].performed       -= ctx => move_right_begin_event?.Invoke(ctx);
    input.actions["move_right"].canceled        -= ctx => move_right_end_event?.Invoke(ctx);
    input.actions["jump"].performed             -= ctx => jump_start_event?.Invoke(ctx);
    input.actions["jump"].canceled              -= ctx => jump_end_event?.Invoke(ctx);
    input.actions["weapon_action_1"].performed  -= ctx => weapon_action_1_event?.Invoke(ctx);
    input.actions["weapon_action_2"].performed  -= ctx => weapon_action_2_event?.Invoke(ctx);
}




}}