using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class PostCourse : MonoBehaviour {

	public void FinishButtonClick()
	{
		var url = "https://stampshot.herokuapp.com/courses";
		var path = "/sdcard/StampShot/course/TestCourse.json";//パス指定
		var json = File.ReadAllText(path);//ファイル読み込み

		 StartCoroutine(Post(url, json));
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
