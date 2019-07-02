using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : Controller {
    DisplayApi api;
    GameObject power_commander;
    bool power_switch;

    void Start(){
        api = DisplayApi.instance;
        power_commander = this.transform.Find("power").gameObject;
        power_switch = false;
    }
    
    void power(){
        api.power();

        if(power_switch){
            power_commander.GetComponent<Renderer>().material.color = Color.white;
        }else{
            power_commander.GetComponent<Renderer>().material.color = Color.red;
        }
        power_switch = !power_switch;
    }

}
