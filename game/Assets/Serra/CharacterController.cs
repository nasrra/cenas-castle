using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

namespace Serra{public class CharacterController : MonoBehaviour{




[Header("References")]
[SerializeField] Rigidbody2D rb;
[SerializeField] LayerMask ground_layer;    
[Header("Values")]
[SerializeField] float move_speed;
[SerializeField] float acceleration; 
[SerializeField] float jump_force;
[SerializeField] float jump_decay;
[SerializeField] float ground_check_dst;
[Header("Constraints")]
[SerializeField] bool can_walk;
[SerializeField] bool can_jump;




void FixedUpdate(){
    if(Physics2D.Raycast(transform.position, Vector2.down, ground_check_dst, ground_layer))
        can_jump = true;
    
    #if UNITY_EDITOR
    Debug.DrawRay(transform.position, Vector3.down * ground_check_dst, Color.green);
    #endif
}

#region move_left
public void move_left_begin(){
    if(can_walk)
        StartCoroutine("move_left");
}

IEnumerator move_left(){
    while (true) {
        // Calculate the difference between the current velocity and the desired maximum speed
        float speedDifference = -move_speed - rb.velocity.x;
        // Apply a force proportional to the speed difference
        float forceMagnitude = acceleration * Mathf.Clamp01(-speedDifference / move_speed) * Time.deltaTime;
        rb.AddForce(new Vector2(-forceMagnitude, 0.0f));
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
        // Calculate the difference between the current velocity and the desired maximum speed
        float speedDifference = move_speed - rb.velocity.x;

        // Apply a force proportional to the speed difference
        float forceMagnitude = acceleration * Mathf.Clamp01(speedDifference / move_speed) * Time.deltaTime;
        rb.AddForce(new Vector2(forceMagnitude, 0.0f));

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
        rb.AddForce(new Vector2(0.0f, force * Time.deltaTime));
        force -= Time.deltaTime * jump_decay * jump_force;
        yield return null;
    }
}

public void jump_end(){
    StopCoroutine("jump");
    can_jump = false;
}
#endregion

public void apply_force(ForceMode2D mode, Vector2 force){
    rb.AddForce(force, mode);
}

public void set_velocity(Vector2 velocity){
    rb.velocity = velocity;
}




}}