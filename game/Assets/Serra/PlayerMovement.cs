using System.Collections;
using UnityEngine;

namespace Serra{public class PlayerMovement : MonoBehaviour{




[Header("References")]
[SerializeField] Rigidbody2D rb;
[SerializeField] LayerMask ground_layer;    
[Header("Values")]
[SerializeField] float move_speed; 
[SerializeField] float jump_force;
[SerializeField] float jump_decay;
[SerializeField] float ground_check_dst;
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

void Update(){
    if(Physics2D.Raycast(transform.position, Vector2.down, ground_check_dst, ground_layer))
        can_jump = true;
    Debug.DrawRay(transform.position, Vector3.down * ground_check_dst, Color.green);
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
    can_jump = false;
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