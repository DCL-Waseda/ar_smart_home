using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    // 電源が入ったらparticleがつく
    private bool is_powered = false;
    protected bool IsPowered {
        get { return is_powered; }
        set { is_powered = value; }
    }

    protected void switch_power(){
        if(!IsPowered){
            change_color((Material)Resources.Load("Materials/powered"));
            IsPowered = true;
            MyoGestureManager.color_changed = true;
        }else{
            change_color((Material)Resources.Load("Materials/not_focused"));
            IsPowered = false;
            MyoGestureManager.color_changed = true;
        }
    }

    protected void effect(string target_effect){
        this.transform.Find(target_effect).gameObject.GetComponent<ParticleSystem>().Play();
    }


    protected void change_color(Material target){
        Material[] targets = this.gameObject.GetComponent<Renderer>().materials;
        for(int i = 0; i < targets.Length; i++){
            targets[i] = target;
        }
        this.gameObject.GetComponent<Renderer>().materials = targets;
    }

    // 各家電APIインスタンスに操作名を投げる
    protected virtual void button_behavior(string method_name){

    }
}
