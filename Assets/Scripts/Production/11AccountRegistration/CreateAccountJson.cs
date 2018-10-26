using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CreateAccountJson : MonoBehaviour {
	public InputField InputAccountName;
    public InputField InputAccountPass;

	[Serializable]
	public class Account
	{
		public string   name    = string.Empty;
		public string   pass    = string.Empty;
	} 
	public void PushCreateAccountButton()
	{
		var url = "https://stampshot.herokuapp.com/";
		var account = new Account();

        //データ入力
		account.name = InputAccountName.text;
		account.pass = InputAccountPass.text;

        // JSONにシリアライズ
        var json = JsonUtility.ToJson (account,true);

		StartCoroutine(Post(url + "users", json));

        // jsonファイルをフォルダに保存する
        var path = "/sdcard/StampShot/" + account.name + ".json";//ファイル名をspot名にしてファイル指定
        var writer = new StreamWriter (path, false); // 上書き
        writer.WriteLine (json);
        writer.Flush ();
        writer.Close ();

        SceneManager.LoadScene("2Menu");
	}

	IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.Send();

        Debug.Log("Status Code: " + request.responseCode);
    }
}
