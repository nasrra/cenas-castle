using System;
using UnityEngine.InputSystem;

namespace Serra{public class GameplayActionMap : ActionMap{

public event Action<InputAction.CallbackContext> interact_event;

public override void subscribe_to_events(PlayerInput input){
    input.actions["interact"].performed += ctx => interact_event?.Invoke(ctx);
}
public override void unsubscribe_to_events(PlayerInput input){
    input.actions["interact"].performed -= ctx => interact_event?.Invoke(ctx);
}

}}