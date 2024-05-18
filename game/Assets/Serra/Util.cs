using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Serra{ public static class Util{




public static IEnumerator new_timer(float wait_time, Action callback){
    return new Timer().create_ienum(wait_time, callback);
}




}}

namespace Serra{ public class Timer{
public IEnumerator create_ienum(float wait_time, Action callback){
   yield return new WaitForSeconds(wait_time);
   callback?.Invoke();
}
}}