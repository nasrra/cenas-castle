using System.Collections;
using UnityEngine;

namespace Serra{public class PlayerMovement : MonoBehaviour{



[Header("References")]
[SerializeField] Rigidbody2D rb;    
[Header("Speeds")]
[SerializeField] float move_speed;
[SerializeField] float jump_force;




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
    StartCoroutine("move_left");
}

IEnumerator move_left(){
    while(true){
        Debug.Log("move_left!");
        rb.AddForce(new Vector2(-0.1f, 0.0f));
        yield return null;
    }
}

public void move_left_end(){
    StopCoroutine("move_left");
}
#endregion
#region move_right
public void move_right_begin(){
    StartCoroutine("move_right");
}

IEnumerator move_right(){
    while(true){
        Debug.Log("move_right!");
        rb.AddForce(new Vector2(0.1f, 0.0f));
        yield return null;
    }
}

public void move_right_end(){
    StopCoroutine("move_right");
}
#endregion
#region jump
public void jump_begin(){
    StartCoroutine("jump");
}

IEnumerator jump(){
    while(true){
        Debug.Log("jump!");
        rb.AddForce(new Vector2(0.0f, 0.1f));
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