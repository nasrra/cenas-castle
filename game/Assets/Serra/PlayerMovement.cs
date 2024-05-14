using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Serra{public class PlayerMovement : MonoBehaviour{




[Header("References")]
[SerializeField] Rigidbody2D rb;    
[Header("Speeds")]
[SerializeField] float move_speed; 
[SerializeField] float jump_force;
[SerializeField] float jump_decay;
[Header("Constraints")]
[SerializeField] bool can_walk;
[SerializeField] bool can_jump;




void Start(){
    if(InputSystem.get_action_map("Gameplay") is GameplayActionMap action_map){
        action_map.move_left_begin_event    += ctx => move_left_begin(); 
        action_map.move_left_end_event      += ctx => move_left_end();
        action_map.move_right_begin_event   += ctx => move_right_begin(); 
        action_map.move_right_end_event     += ctx => move_right_end();
        action_map.jump_start_event         += ctx => jump_begin();
        action_map.jump_end_event           += ctx => jump_end();
    }
}

#region move_left
public void move_left_begin(){
    if(can_walk)
        StartCoroutine("move_left");
}

IEnumerator move_left(){
    while(true){
        rb.AddForce(new Vector2(-move_speed, 0.0f));
        yield return null;
    }
}

public void move_left_end(){
    StopCoroutine("move_left");
}
#endregion
#region move_right
public void move_right_begin(){
    if(can_walk)
        StartCoroutine("move_right");
}

IEnumerator move_right(){
    while(true){
        rb.AddForce(new Vector2(move_speed, 0.0f));
        yield return null;
    }
}

public void move_right_end(){
    StopCoroutine("move_right");
}
#endregion
#region jump
public void jump_begin(){
    if(can_jump)
        StartCoroutine("jump");
}

IEnumerator jump(){
    float force = jump_force;
    while(force > 0.0){
        rb.AddForce(new Vector2(0.0f, force));
        force -= Time.deltaTime * jump_decay * jump_force;
        yield return null;
    }
}

public void jump_end(){
    StopCoroutine("jump");
}
#endregion

void OnDestroy(){
    if(InputSystem.get_action_map("Gameplay") is GameplayActionMap action_map){
        action_map.move_left_begin_event    -= ctx => move_left_begin(); 
        action_map.move_left_end_event      -= ctx => move_left_end();
        action_map.move_right_begin_event   -= ctx => move_right_begin(); 
        action_map.move_right_end_event     -= ctx => move_right_end();
        action_map.jump_start_event         -= ctx => jump_begin();
        action_map.jump_end_event           -= ctx => jump_end();    
    }    
}




}}