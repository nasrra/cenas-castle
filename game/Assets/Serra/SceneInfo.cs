using System;
using System.Xml.Serialization;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Serra{ public class SceneInfo : MonoBehaviour{




public SerializedDictionary<string, Transform> entry_points = new SerializedDictionary<string, Transform>();




void Awake(){
    Managers.scene_info = this;
}




}}