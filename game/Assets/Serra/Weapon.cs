using UnityEngine;

namespace Serra{ public abstract class Weapon : MonoBehaviour{


[Header("Weapon Components")]
[SerializeField] protected Animator animator;
[SerializeField] protected Collider2D dmg_collider;
[Header("Weapon Variables")]
[SerializeField] protected float dmg;




public abstract void action_1();
public abstract void action_2();
public abstract void enable_dmg_collider();
public abstract void disable_dmg_collider();




}}