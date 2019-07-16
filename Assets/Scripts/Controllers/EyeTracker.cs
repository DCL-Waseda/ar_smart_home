using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTracker : MonoBehaviour {

    public GameObject FocusedObject;
    GestureTracker GT;
    Intermediary Im;
    bool tracking = true;

    void Start()
    {
        GT = gameObject.GetComponent<GestureTracker>();
        Im = gameObject.GetComponent<Intermediary>();
    }
    // Update is called once per frame
    void Update () {
        GameObject oldFocusedObject=FocusedObject;
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        RaycastHit hitInfo;
        if (tracking&&Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            tracking = false;
            FocusedObject = hitInfo.collider.gameObject;
            if (!Im.GestureCheck(FocusedObject, GT.ges_status)) {//チェックに失敗したら追跡再開
                tracking = true;
            }
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }
        if (FocusedObject!=oldFocusedObject) {
            tracking = true;
        }
    }
}
