using UnityEngine;

namespace Serra{ public class TestEnemy : Enemy{




public override void damaged(){
    Debug.Log("played damage animation");
}
public override void death(){
    Debug.Log("played death animation");
    Destroy(gameObject);
}
public override void healed(){
    Debug.Log("played healed animation");
}




}}