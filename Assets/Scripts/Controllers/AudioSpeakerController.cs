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
            default: 
                break;
        }
    }
}
