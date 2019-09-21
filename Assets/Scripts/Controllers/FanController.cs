using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanController : Controller {
    FanApi api;
	enum Volume {
        High, 
        Mid, 
        Low
    }
    private  Volume volume;
	private GameObject canvas;
	private GameObject text;
    private const int CHILD_OBJECT_NUM = 16;

    void Awake(){
		// canvasをfindしてアクティブ非アクティブにするが、find時はアクティブである必要がある
		canvas = gameObject.transform.Find("Canvas").gameObject;
        text = canvas.transform.Find("Panel").gameObject.transform.Find("Text").gameObject;
		canvas.SetActive(false);
	}

    void Start(){
        api = FanApi.instance;
        volume = Volume.Low;
    }

    void Update(){
        update_status_text();
    }

    protected override void button_behavior(string method_name){
        if(method_name == "make_a_fist"){
            switch_power();
            Debug.Log("power");
            return;
        }

        if(IsPowered){
            switch(method_name){
				case "double_tap": 
					switch_volume();
                    Debug.Log("switch_volume");
                    break;
                default: 
                    Debug.Log("default");
                    break;
            }
        }
    }

	private void switch_volume(){
        if(volume == Volume.Low){
            volume = Volume.Mid;
        }else if(volume == Volume.Mid){
            volume = Volume.High;
        }else{
            volume = Volume.Low;
        }
    }

    private void switch_canvas(){
        canvas.SetActive(!canvas.activeSelf);
    }

    private void update_status_text(){
        string txt = 
            "volume: " + volume.ToString() + "\n";
        text.GetComponent<Text>().text = txt;
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
