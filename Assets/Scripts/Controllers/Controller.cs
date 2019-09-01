using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Controller : MonoBehaviour, IInputClickHandler {

    // ボタンの表示
    public void OnInputClicked(InputClickedEventData eventData) {
        foreach (Transform childTransform in gameObject.transform){
            childTransform.gameObject.SetActive(!childTransform.gameObject.activeSelf);
        }
    }

    // 各家電APIインスタンスに操作名を投げる
    protected virtual void button_behavior(string method_name){

    }
}
