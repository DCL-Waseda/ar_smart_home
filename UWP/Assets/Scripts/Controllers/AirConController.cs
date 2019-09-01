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
            default: 
                break;
        }
    }
}
