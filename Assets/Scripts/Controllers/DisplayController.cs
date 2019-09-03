using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : Controller {
    DisplayApi api;

    void Start(){
        api = DisplayApi.instance;
    }

    // 各家電APIインスタンスに操作名を投げる
    protected override void button_behavior(string method_name){
        switch(method_name){
            case "power": 
                switch_particle("power");
                api.power();
                break;
            case "volume_up": 
                api.volume_up();
                break;
            case "volume_down": 
                api.volume_down();
                break;
            default: 
                Debug.Log("default");
                break;
        }
    }
}
