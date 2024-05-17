using Unity.VisualScripting;
using UnityEngine;

namespace Serra{ public class Health : MonoBehaviour{




[Header("Variables")]
[SerializeField] float max_health = 100;
[SerializeField] float curr_health = 100;




public void damage(float dmg){
    curr_health -= dmg;
    if(curr_health <= 0)
        Debug.Log(gameObject.name+" DIED!");
}

public void heal(float health){
    curr_health += health;
    if(curr_health >= max_health)
        curr_health = max_health;
}




}}