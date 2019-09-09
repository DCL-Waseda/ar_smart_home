using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirConController : Controller {
    AirConApi api;
    // 0: cooler, 1: warmer
    enum Mode {
        Cooler, 
        Warmer
    };
    private Mode mode;

    void Start(){
        api = AirConApi.instance;
        mode = Mode.Cooler;
    }
    
    protected override void button_behavior(string method_name){
        switch(method_name){
            case "power": 
                aircon_power();
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

    protected void aircon_power(){
        if(!IsPowered){
            change_color((Material)Resources.Load("Materials/cooler"));
            mode = Mode.Cooler;
            IsPowered = true;
            MyoGestureManager.color_changed = true;
        }else{
            change_color((Material)Resources.Load("Materials/not_focused"));
            IsPowered = false;
            MyoGestureManager.color_changed = true;
        }
    }

    private void switch_mode(){
        if(mode == Mode.Cooler){
            // cooler -> warmer
            change_color((Material)Resources.Load("Materials/warmer"));
            mode = Mode.Warmer;
            MyoGestureManager.color_changed = true;
        }else{
            // warmer -> cooler
            change_color((Material)Resources.Load("Materials/cooler"));
            mode = Mode.Cooler;
            MyoGestureManager.color_changed = true;
        }
    }
}
