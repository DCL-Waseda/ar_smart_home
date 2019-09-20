using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
