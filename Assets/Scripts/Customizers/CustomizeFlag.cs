using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeFlag : MonoBehaviour {

	Image image;
    CustomizeController CC;
	// Use this for initialization
	void Start () {
		image=transform.parent.gameObject.GetComponent<Image>();
		CC=transform.parent.parent.gameObject.GetComponent<CustomizeController>();
	}
	
	void TappedImage(){
		CC.Reset();
		image.color=new Color(1,1,1,1);
        CustomizeData.Device[CC.now_costom].key = transform.parent.gameObject.name;
	}
}
