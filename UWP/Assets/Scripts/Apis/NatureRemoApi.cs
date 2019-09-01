using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using NatureRemo;

public class NatureRemoApi {

    public void signal_post(string id){
        string uri = signal_uri(id);
        CoroutineHandler.StartStaticCoroutine(post(uri));
    }

    private string signal_uri(string signal_id){
        return "https://api.nature.global/1/signals/" + signal_id +"/send";
    }

    IEnumerator post(string uri){
        Debug.Log("post: " + uri);
 
        var request = new UnityWebRequest(uri, "POST");
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Authorization", "Bearer " + Const.TOKEN);
        yield return request.SendWebRequest();
 
        Debug.Log("Status Code: " + request.responseCode);
        if (request.isNetworkError){
            Debug.Log(request.error);
        }else{
            // Show results as text
            Debug.Log(request.downloadHandler.text);
        }
 
    }
}
