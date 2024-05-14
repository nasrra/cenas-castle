using UnityEngine.InputSystem;


namespace Serra{ public abstract class ActionMap{


public abstract void subscribe_to_events(PlayerInput input);
public abstract void unsubscribe_to_events(PlayerInput input);


}}