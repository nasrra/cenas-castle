using System;
using UnityEngine;

namespace Serra{public class Interactable : MonoBehaviour{




// TODO: might want to add a list of all interactors in range, so a bug does not occur.
[Header("Constraints")]
public bool is_interactable = true;
public event Action interation_event;




// TODO: might need to change it to check if the component is also active.
void OnTriggerEnter2D(Collider2D other){
    Interactor interactor = other.gameObject.GetComponent<Interactor>();
    if(interactor != null)
        interactor.interact_event += interact;
}

void OnTriggerExit2D(Collider2D other){
    Interactor interactor = other.gameObject.GetComponent<Interactor>();
    if(interactor != null)
        interactor.interact_event -= interact;
}

public void interact(){
    interation_event?.Invoke();
}




}}