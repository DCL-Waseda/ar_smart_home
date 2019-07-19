using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermediary : MonoBehaviour {
	
    public bool GestureCheck(GameObject Focused, string gesture) {
        for (int i=0;i<CustomizeData.Device.Length;i++) {
            if (Focused.name==CustomizeData.Device[i].device_name) {
                if (gesture == CustomizeData.Device[i].key)
                {
                    //家電の関数呼び出し
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        return false;
    }
}
