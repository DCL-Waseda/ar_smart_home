using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirConController : Controller {
    AirConApi api;

    void Start(){
        api = AirConApi.instance;
    }
    
    protected override void button_behavior(string method_name){
        switch(method_name){
            case "power": 
                switch_particle("power");
                Debug.Log("power");
                break;
            case "volume_up": 
                Debug.Log("air_up");
                break;
            case "volume_down": 
                Debug.Log("air_down");
                break;
            default: 
                Debug.Log("default");
                break;
        }
    }
}
