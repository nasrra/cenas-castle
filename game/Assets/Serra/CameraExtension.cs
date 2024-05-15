using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace Serra{ public class CameraExtenstion : MonoBehaviour{


[Header("References")]
[SerializeField] new Camera camera;
[SerializeField] Transform target;
[Header("Variables")]
[SerializeField] CameraType camera_type;
[SerializeField] Vector3 offset;
[SerializeField] float follow_speed;
[SerializeField] float lerp_distance;
[SerializeField] bool starting_camera;

void Start(){
    Managers.camera_controller.add_camera(this);
    gameObject.SetActive(false);
    if(starting_camera == true)
        Managers.camera_controller.set_active_camera(this);
}

public CameraType get_type(){
    return camera_type;
}

void OnDestroy(){
    Managers.camera_controller.remove_camera(this);
}


}}