using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Serra{ public static class InputSystem{


[SerializeField] static PlayerInput input;
[SerializeField] static ActionMap action_map;
private static Dictionary<string, ActionMap> maps = new Dictionary<string, ActionMap>{
    {"Gameplay", new GameplayActionMap()},
};


public static void set_player_input(PlayerInput player_input){
    Debug.Log(to_string()+" Player Input Set");
    input = player_input;
}

public static void set_action_map(string map){
    if(action_map != null)
        action_map.unsubscribe_to_events(input);
    input.SwitchCurrentActionMap(map);
    action_map = get_action_map(map);
    action_map.subscribe_to_events(input);
}

public static ActionMap get_action_map(string map){
    return maps.ContainsKey(map)? maps[map] : throw new NullReferenceException(map+" not set up in action maps!");
}

public static string to_string(){
    return "[InputSystem]";
}


}}
