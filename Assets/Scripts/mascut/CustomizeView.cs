using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class CustomizeView : MonoBehaviour {

	GameObject FocusedObject;
	GestureRecognizer recognizer;
	public string key_one="Spread";
	// Use this for initialization
	void Awake () {
		recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject!= null)
            {
                FocusedObject.SendMessageUpwards("TappedImage");
            }
        };
        recognizer.StartCapturingGestures();
    }
	
	// Update is called once per frame
	void Update () {
		var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        RaycastHit hitInfo;
		if (Physics.Raycast(headPosition, gazeDirection, out hitInfo)){
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }else{
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }
	}
	
	public void Reset(){
		for(int i=0;i<4;i++){
			transform.GetChild(i).gameObject.GetComponent<Image>().color=new Color(1,1,1,0.2f);
		}
	}
}
