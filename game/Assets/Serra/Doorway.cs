using Unity.VisualScripting;
using UnityEngine;

namespace Serra{ public class Doorway : MonoBehaviour{




[Header("Components")]
[SerializeField] Interactable interactable;
[SerializeField] SceneLoader scene_loader;




void Start(){
    //link events
    interactable.interation_event += scene_loader.load_scene;
}

void OnDestroy(){
    //links events
    interactable.interation_event -= scene_loader.load_scene;
}




}}