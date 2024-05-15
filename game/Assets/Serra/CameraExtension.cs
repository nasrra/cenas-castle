using UnityEngine;

namespace Serra{ public class CameraExtenstion : MonoBehaviour{


[Header("References")]
[SerializeField] new Camera camera;
public Transform target;
[Header("Variables")]
public Vector3 offset;
public float follow_speed;
public float lerp_distance;
public bool starting_camera;

void Start(){
    Managers.camera_controller.add_camera(this);
    gameObject.SetActive(false);
    if(starting_camera == true)
        Managers.camera_controller.set_active_camera(this);
}

void OnDestroy(){
    Managers.camera_controller.remove_camera(this);
}


}}