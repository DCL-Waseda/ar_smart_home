﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirConController : Controller {
    AirConApi api;
    // 0: cooler, 1: warmer
    enum Mode {
        Cooler, 
        Warmer
    };
    private Mode mode;
    enum Volume {
        High, 
        Mid, 
        Low
    }
    private  Volume volume;
    private GameObject canvas;
    private GameObject text;
    private int target_temperature;

    void Awake(){
		// canvasをfindしてアクティブ非アクティブにするが、find時はアクティブである必要がある
		canvas = gameObject.transform.Find("Canvas").gameObject;
        text = canvas.transform.Find("Panel").gameObject.transform.Find("Text").gameObject;
		canvas.SetActive(false);
	}

    void Start(){
        api = AirConApi.instance;
        mode = Mode.Cooler;
        volume = Volume.Low;
        target_temperature = 25;
    }

    void Update(){
        update_status_text();
    }

    protected override void button_behavior(string method_name){
        if(method_name == "make_a_fist"){
            aircon_power();
            Debug.Log("power");
            return;
        }

        if(IsPowered){
            switch(method_name){
                case "wave_right": 
                    effect("buff");
                    target_temperature++;
                    Debug.Log("temperature_up");
                    break;
                case "wave_left": 
                    effect("debuff");
                    target_temperature--;
                    Debug.Log("temperature_down");
                    break;
                case "double_tap": 
                    switch_volume();
                    Debug.Log("switch_volume");
                    break;
                case "spread_fingers": 
                    switch_mode();
                    Debug.Log("switch_mode");
                    break;
                default: 
                    Debug.Log("default");
                    break;
            }
        }
    }

    private void aircon_power(){
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
            "temperature: " + target_temperature.ToString() + "\n" +
            "volume: " + volume.ToString() + "\n";
        text.GetComponent<Text>().text = txt;
    }
}
