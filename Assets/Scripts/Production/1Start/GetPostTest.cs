using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class GetPostTest : MonoBehaviour {

    void Start () {
        // IEnumeratorインターフェースを継承したメソッドは、StartCoroutineでコールする
        StartCoroutine(Get("https://stampshot.herokuapp.com/user/id"));
    }

    IEnumerator Get (string url) {
        // HEADERはHashtableで記述
        Hashtable header = new Hashtable ();
        header.Add ("Accept-Language", "ja");

        // 送信開始
        WWW www = new WWW (url, null, header);
        yield return www;

        // 成功
        if (www.error == null) {
            Debug.Log("Get Success");

            Debug.Log(www.text);
        }
        // 失敗
        else{
            Debug.Log("Get Failure");           
        }
    }


}

