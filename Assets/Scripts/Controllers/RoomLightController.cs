using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLightController : Controller {
    RoomLightApi api;

    void Start(){
        api = RoomLightApi.instance;
    }

    protected override void button_behavior(string method_name){
        if(method_name == "make_a_fist"){
            switch_power();
            Debug.Log("power");
            return;
        }

        if(IsPowered){
            switch(method_name){
                default: 
                    Debug.Log("default");
                    break;
            }
        }
    }
}
