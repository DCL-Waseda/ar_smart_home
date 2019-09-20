using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : Controller {
    CurtainApi api;

    void Start(){
        api = CurtainApi.instance;
    }

    protected override void button_behavior(string method_name){
        if(method_name == "make_a_fist"){
            Debug.Log("open/close");
            return;
        }
    }
}
