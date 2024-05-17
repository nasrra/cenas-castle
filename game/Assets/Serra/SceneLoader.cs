using Unity.VisualScripting;
using UnityEngine;
namespace Serra{ public class SceneLoader : MonoBehaviour{




[Header("Enter Variables")]
[SerializeField] string entry_point;
[Header("Exit Variables")]
[SerializeField] string scene_to_load;
[SerializeField] string exit_point;




void Start(){
    // add entry point to a data base.
}

public bool is_entry_point(string entry_point){
    return this.entry_point == entry_point;
}

public void load_scene(){
    Debug.Log("loading scene "+scene_to_load);
}

void OnDestroy(){
    // remove from data base.
}




}}