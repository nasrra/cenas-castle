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
    CameraController.add_camera(this);
    gameObject.SetActive(false);
    if(starting_camera == true)
        CameraController.set_active_camera(this);
}

void OnDestroy(){
    CameraController.remove_camera(this);
}


}}