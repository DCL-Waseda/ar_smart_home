using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSpeakerController : Controller {
    AudioSpeakerApi api;
    private int volume;
    private GameObject canvas;
    private GameObject text;

    void Awake(){
		// canvasをfindしてアクティブ非アクティブにするが、find時はアクティブである必要がある
		canvas = gameObject.transform.Find("Canvas").gameObject;
        text = canvas.transform.Find("Panel").gameObject.transform.Find("Text").gameObject;
		canvas.SetActive(false);
	}

    void Start(){
        api = AudioSpeakerApi.instance;
        volume = 18;
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
                case "wave_right": 
                    volume++;
                    effect("buff");
                    Debug.Log("volume_up");
                    break;
                case "wave_left": 
                    volume--;
                    effect("debuff");
                    Debug.Log("volume_down");
                    break;
                default: 
                    Debug.Log("default");
                    break;
            }
        }
    }

    private void switch_canvas(){
        canvas.SetActive(!canvas.activeSelf);
    }

    private void update_status_text(){
        string txt = "volume: " + volume.ToString() + "\n";
        text.GetComponent<Text>().text = txt;
    }
}
