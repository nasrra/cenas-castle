using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

namespace Serra{ public static class CameraController{


static Dictionary<string, CameraExtenstion> cameras = new Dictionary<string, CameraExtenstion>();
static CameraExtenstion active_camera;


public static void add_camera(CameraExtenstion cam){
    cameras.Add(cam.gameObject.name, cam);
    Debug.Log(cam.gameObject.name + " added camera!");
}

public static void set_active_camera(CameraExtenstion cam = null){
    if(active_camera != null)
        active_camera.gameObject.SetActive(false);
    active_camera = cam;
    if(active_camera != null)
        active_camera.gameObject.SetActive(true);
}

public static CameraExtenstion get_actve_camera(){
    return active_camera;
}

public static void remove_camera(CameraExtenstion cam){
    cameras.Remove(cam.gameObject.name);
}


}}