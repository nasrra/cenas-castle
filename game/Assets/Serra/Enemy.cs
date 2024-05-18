using UnityEditor;
using UnityEngine;

namespace Serra{ public abstract class Enemy : MonoBehaviour{




[Header("Enemy Components")]
[SerializeField] protected Health health;




void Awake(){
    health.death_event  += unlink;
    health.death_event  += death;
    health.damage_event += damaged;
    health.heal_event   += healed;
}

public abstract void death();
public abstract void damaged();
public abstract void healed();

void unlink(){
    health.death_event  -= death;
    health.death_event  -= unlink;
    health.damage_event -= damaged;
    health.heal_event   -= healed;    
}




}}