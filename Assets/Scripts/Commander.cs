using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Commander : MonoBehaviour, IInputClickHandler {
	public void OnInputClicked(InputClickedEventData eventData) {
		gameObject.transform.root.gameObject.SendMessageUpwards("button_behavior", gameObject.name, SendMessageOptions.DontRequireReceiver);
    }
}
