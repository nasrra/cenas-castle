using System;
using UnityEngine;

namespace Serra{ public class WeaponHolder : MonoBehaviour{




[Header("Weapon")]
[SerializeField] Weapon weapon;
public event Action
    action_1_event,
    action_2_event;




void Start(){
    link_weapon();
}

void link_weapon(){
    if(weapon == null)
        return;
    action_1_event += weapon.action_1;
    action_2_event += weapon.action_2;
}

public void set_weapon(Weapon weapon){
    unlink_weapon();
    this.weapon = weapon;
    link_weapon();
}

public void use_action_1(){
    action_1_event?.Invoke();
}

public void use_action_2(){
    action_2_event?.Invoke();
}

void unlink_weapon(){
    if(weapon == null)
        return;
    action_1_event -= weapon.action_1;
    action_2_event -= weapon.action_2;
}

void OnDestroy(){
    unlink_weapon();
}




}}