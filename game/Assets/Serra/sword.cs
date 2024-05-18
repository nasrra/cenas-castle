using UnityEngine;

namespace Serra{public class Sword : Weapon{




public override void action_1(){
    Debug.Log("swing sword!");
    animator.SetTrigger("swing_sword");
}

public override void action_2(){
    Debug.Log("parry!");
}

public override void enable_dmg_collider(){
    dmg_collider.enabled = true;
}

public override void disable_dmg_collider(){
    dmg_collider.enabled = false;
}

void OnTriggerEnter2D(Collider2D other){
    Health other_health = other.GetComponent<Health>();
    if(other.tag == "Enemy"){
        if(other_health != null)
            other_health.damage(dmg);
    }
}





}}