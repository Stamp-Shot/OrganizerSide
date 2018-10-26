using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DirectoryDisplay : MonoBehaviour {

	public InputField Input;
	public Text text;

	public void PushGetButton()
	{
		var path = "https://stampshot.herokuapp.com/" + Input.text;
		StartCoroutine(GetText(path));
	}

	IEnumerator GetText(string path) 
	{
        UnityWebRequest request = UnityWebRequest.Get(path);
 
        // リクエスト送信
        yield return request.Send();
 
        // 通信エラーチェック
        if (request.isNetworkError) 
		{
            Debug.Log(request.error);
        } 
		else 
		{
            if (request.responseCode == 200) 
			{
                // UTF8文字列として取得する
                string GetText = request.downloadHandler.text;
				text.text = GetText;
            }
        }
    }
}
