using System;
using UnityEngine;

namespace Serra{ public class Health : MonoBehaviour{




[Header("Variables")]
[SerializeField] float max_health = 100;
[SerializeField] float curr_health = 100;
[Header("Constraints")]
[SerializeField] bool can_damage = true;
[SerializeField] float damage_cooldown;
[SerializeField] bool can_heal = true;
[SerializeField] float heal_cooldown;
Coroutine heal_timer, damage_timer;
public event Action 
    heal_event,
    damage_event,
    death_event,
    damage_callback_event;




void Awake(){
    damage_callback_event += damage_timer_end;
}

public void damage(float dmg){
    if(damage_timer != null)
        return;

    curr_health -= dmg;
    damage_event?.Invoke();
    if(curr_health <= 0)
        death_event?.Invoke();

    damage_timer = StartCoroutine(Util.new_timer(damage_cooldown, damage_callback_event));
}

void damage_timer_end(){
    damage_timer = null;
    Debug.Log("Timeout!");
}

public void heal(float health){
    curr_health += health;
    heal_event?.Invoke();
    if(curr_health >= max_health)
        curr_health = max_health;
}

void OnDestroy(){
    damage_callback_event -= damage_timer_end;
}




}}