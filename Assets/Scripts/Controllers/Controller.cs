using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    // 電源が入ったらparticleがつく
    private bool is_powered = false;
    private bool IsPowered {
        get { return is_powered; }
        set { is_powered = value; }
    }
    protected void power_particle(){
        if(!IsPowered){
            this.gameObject.GetComponent<ParticleSystem>().Play();
            IsPowered = true;
        }else{
            this.gameObject.GetComponent<ParticleSystem>().Stop();
            IsPowered = false;
        }
    }

    // 各家電APIインスタンスに操作名を投げる
    protected virtual void button_behavior(string method_name){

    }
}
