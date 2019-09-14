using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLightController : Controller {
    RoomLightApi api;

    void Start(){
        api = RoomLightApi.instance;
    }
    
    protected override void button_behavior(string method_name){
        switch(method_name){
            case "make_a_fist": 
                switch_power();
                Debug.Log("power");
                break;
            default: 
                Debug.Log("default");
                break;
        }
    }
}
