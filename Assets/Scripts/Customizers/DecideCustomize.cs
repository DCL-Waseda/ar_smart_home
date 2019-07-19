using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecideCustomize : MonoBehaviour {

    CustomizeController CC;

    void Start()
    {
        CC = transform.parent.parent.gameObject.GetComponent<CustomizeController>();
    }
    void TappedImage () {
        switch (CC.now_costom) {
            case 0:
                CustomizeData.Device[0].device_name = "TV";
                CC.now_costom += 1;
                SceneManager.LoadScene("Main");//適宜移動
                break;
            default:
                break;
        }
        
	}
}
