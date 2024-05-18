using System;
using UnityEngine;

namespace Serra{ public class Health : MonoBehaviour{




[Header("Variables")]
[SerializeField] float max_health = 100;
[SerializeField] float curr_health = 100;
public event Action 
    heal_event,
    damage_event,
    death_event;
    




public void damage(float dmg){
    curr_health -= dmg;
    damage_event?.Invoke();
    if(curr_health <= 0)
        death_event?.Invoke();
}

public void heal(float health){
    curr_health += health;
    heal_event?.Invoke();
    if(curr_health >= max_health)
        curr_health = max_health;
}




}}