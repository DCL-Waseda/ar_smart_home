using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pose=Thalmic.Myo.Pose;
using UnityEngine.UI;

public class CustomizeView : MonoBehaviour {

	public GameObject myo;
	ThalmicMyo thalmicMyo;
	float cooltime=0;
	bool input_right=true;
	int target=0;
	// Use this for initialization
	void Start () {
		thalmicMyo=myo.GetComponent<ThalmicMyo>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!input_right){
			cooltime--;
			if(cooltime<0){
				cooltime=0;
				input_right=true;
			}
		}
		//Fist();
		WaveIn();
		WaveOut();
	}
	void Fist(){
		if(thalmicMyo.pose==Pose.Fist){
			//Enter
			Debug.Log("Fist");
		}
	}
	void WaveIn(){
		if(thalmicMyo.pose==Pose.WaveIn&&input_right){
			//Left
			if(target!=0){
				Reset();
				target-=1;
				transform.GetChild(target).gameObject.GetComponent<Image>().color=new Color(1,1,1,1);
			}
		}
	}
	void WaveOut(){
		if(thalmicMyo.pose==Pose.WaveOut&&input_right){
			//Right
			Debug.Log("Goright");
			if(target!=3){
				Reset();
				target+=1;
				transform.GetChild(target).gameObject.GetComponent<Image>().color=new Color(1,1,1,1);
			}
		}
	}
	void Reset(){
		foreach (Transform child in transform)
		{
			child.GetComponent<Image>().color=new Color(1,1,1,0.2f);
			input_right=false;
			cooltime=60;
		}
	}
}
