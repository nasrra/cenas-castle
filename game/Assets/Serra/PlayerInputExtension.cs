using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Serra{ public class PlayerInputExtension : MonoBehaviour{

[SerializeField] PlayerInput player_input;

void Awake(){
    InputSystem.set_player_input(player_input);
}

}}