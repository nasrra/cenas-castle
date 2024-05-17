using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Serra{ public class SceneLoader : MonoBehaviour{




[Header("Exit Variables")]
[SerializeField] string scene_to_load;
[SerializeField] string exit_point;




public void load_scene(){
    SceneManager.LoadScene(scene_to_load);
    Managers.scene_entry_point = exit_point;
}




}}