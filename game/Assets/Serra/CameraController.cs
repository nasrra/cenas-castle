using System.Collections.Generic;
using UnityEngine;

namespace Serra{ public class CameraController : MonoBehaviour{


Dictionary<string, CameraExtenstion> cameras = new Dictionary<string, CameraExtenstion>();
CameraExtenstion active_camera;


void Awake(){
    Managers.camera_controller = this;
}

public void add_camera(CameraExtenstion cam){
    cameras.Add(cam.gameObject.name, cam);
    Debug.Log(cam.gameObject.name + " added camera!");
}

public void set_active_camera(CameraExtenstion cam = null){
    end_active_camera();
    active_camera = cam;
    begin_active_camera();
}

public CameraExtenstion get_actve_camera(){
    return active_camera;
}

void begin_active_camera(){
    if(active_camera == null)
        return;
    active_camera.gameObject.SetActive(true);
    switch(active_camera.get_type()){
        case CameraType.FOLLOW_TARGET:
            Debug.Log("follow camera!");
            break;
        case CameraType.STATIONARY:
            Debug.Log("stationary camera!");
            break;
        default:
            Debug.Log(active_camera.get_type() + " not set up!");
            break;
    }
}

void end_active_camera(){
    if(active_camera == null)
        return;
    active_camera.gameObject.SetActive(false);
}

public void remove_camera(CameraExtenstion cam){
    cameras.Remove(cam.gameObject.name);
}

void OnDestroy(){
    Managers.camera_controller = this;
}



}}