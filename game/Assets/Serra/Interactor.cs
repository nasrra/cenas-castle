using System;
using UnityEngine;

namespace Serra{public class Interactor : MonoBehaviour{



public event Action interact_event;



public void interact(){
    interact_event?.Invoke();
}




}}