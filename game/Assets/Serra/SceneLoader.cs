using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    SceneManager.LoadScene(scene_to_load);
    Managers.scene_entry_point = entry_point;
}

void OnDestroy(){
    // remove from data base.
}




}}