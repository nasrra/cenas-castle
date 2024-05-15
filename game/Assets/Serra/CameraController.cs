using System.Collections;
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
    StartCoroutine("follow_target");
}

IEnumerator follow_target(){
    while(true){
        active_camera.transform.position = Vector3.LerpUnclamped(active_camera.transform.position, active_camera.offset + active_camera.target.position, Time.deltaTime * active_camera.follow_speed);  
        yield return null;
    }
}

void end_active_camera(){
    if(active_camera != null)
        active_camera.gameObject.SetActive(false);
    StopCoroutine("follow_target");
}

public void remove_camera(CameraExtenstion cam){
    cameras.Remove(cam.gameObject.name);
}

void OnDestroy(){
    Managers.camera_controller = this;
}



}}