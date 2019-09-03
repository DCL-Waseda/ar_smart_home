using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpeakerController : Controller {
    AudioSpeakerApi api;

    void Start(){
        api = AudioSpeakerApi.instance;
    }
    
    protected override void button_behavior(string method_name){
        switch(method_name){
            case "power": 
                power_particle();
                Debug.Log("power");
                break;
            case "volume_up": 
                Debug.Log("volume_up");
                break;
            case "volume_down": 
                Debug.Log("volume_down");
                break;
            default: 
                Debug.Log("default");
                break;
        }
    }
}
