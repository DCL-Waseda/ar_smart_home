using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Controller : MonoBehaviour, IInputClickHandler {

    public void OnInputClicked(InputClickedEventData eventData) {
        foreach (Transform childTransform in gameObject.transform){
            childTransform.gameObject.SetActive(!childTransform.gameObject.activeSelf);
        }
    }

    protected virtual void button_behavior(string method_name){

    }
}
