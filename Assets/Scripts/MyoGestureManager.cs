using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pose = Thalmic.Myo.Pose;

public class MyoGestureManager : MonoBehaviour {
	// Singltonパターン
    private static MyoGestureManager m_Instance;
    public static MyoGestureManager instance {
        get {
            if( m_Instance == null ) m_Instance = new MyoGestureManager();
            return m_Instance;
        }
    }

	private GameObject FocusedObject;
	[SerializeField] private GameObject myo;
	private Pose lastPose_ = Pose.Unknown;
    private ThalmicMyo myo_;

	void Start(){
		myo_ = myo.GetComponent<ThalmicMyo>();
	}
	
	void Update() {
		// 見ているオブジェクトの更新
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo)){
            FocusedObject = hitInfo.collider.gameObject;
			send_message(FocusedObject, "change_color", Resources.Load("Materials/focused"));
        }else{
			if(FocusedObject != null){
				send_message(FocusedObject, "change_color", Resources.Load("Materials/not_focused"));
			}
            FocusedObject = null;
        }

		// myoジェスチャー認識
		// 見ているオブジェクトからapi呼び出し
		// 前回と比較して変化があればイベント発火
		if(FocusedObject != null){
			if (myo_.pose != lastPose_) {
            	lastPose_ = myo_.pose;

            	// ジェスチャに応じて処理を分ける
            	switch (myo_.pose) {
                	case Pose.Fist: 
                    	send_message(FocusedObject, "button_behavior", "power");
                    	break;
               		case Pose.WaveIn: 
						send_message(FocusedObject, "button_behavior", "volume_down");
                    	break;
                	case Pose.WaveOut: 
						send_message(FocusedObject, "button_behavior", "volume_up");
                    	break;
                	case Pose.DoubleTap: 
						send_message(FocusedObject, "button_behavior", "");
                    	break;
					case Pose.FingersSpread: 
						send_message(FocusedObject, "button_behavior", "");
						break;
					default: 
						break;
            	}
        	}
		}
	}

	private void send_message<T>(GameObject target, string method, T arg){
		target.SendMessageUpwards(method, arg, SendMessageOptions.DontRequireReceiver);
	}

}
