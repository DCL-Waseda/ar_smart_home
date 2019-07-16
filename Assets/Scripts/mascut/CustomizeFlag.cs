using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeFlag : MonoBehaviour {

	Image image;
    CustomizeView CV;
	// Use this for initialization
	void Start () {
		image=transform.parent.gameObject.GetComponent<Image>();
		CV=transform.parent.parent.gameObject.GetComponent<CustomizeView>();
	}
	
	void TappedImage(){
		CV.Reset();
		image.color=new Color(1,1,1,1);
		CV.key_one=transform.parent.gameObject.name;
	}
}
