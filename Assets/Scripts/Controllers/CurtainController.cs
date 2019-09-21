using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : Controller {
    CurtainApi api;
    private const int CHILD_OBJECT_NUM = 3;

    void Start(){
        api = CurtainApi.instance;
    }

    protected override void button_behavior(string method_name){
        if(method_name == "make_a_fist"){
            Debug.Log("open/close");
            return;
        }
    }

    protected override void change_color(Material target){
        for (int i = 0; i < CHILD_OBJECT_NUM; i++){
            GameObject child_object = this.GetComponent<Transform>().Find(i.ToString()).gameObject;
            Material[] targets = child_object.GetComponent<Renderer>().materials;
            for(int j = 0; j < targets.Length; j++){
                targets[j] = target;
            }
            child_object.GetComponent<Renderer>().materials = targets;
       }
    }
}
