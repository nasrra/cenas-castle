using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Serra{ public static class InputSystem{

private static PlayerInput input;


public static void set_player_input(PlayerInput player_input){
    Debug.Log(to_string()+" Player Input Set: "+player_input);
    input = player_input;
}

public static string to_string(){
    return "[InputSystem]";
}


}}
