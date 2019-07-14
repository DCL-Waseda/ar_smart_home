using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeFlag : MonoBehaviour {

	Image image;
	CustomizeView CV;
	// Use this for initialization
	void Start () {
		image=gameObject.GetComponent<Image>();
		CV=transform.root.gameObject.GetComponent<CustomizeView>();
	}
	
	void TappedImage(){
		CV.Reset();
		image.color=new Color(1,1,1,1);
		CV.key_one=gameObject.name;
	}
}
