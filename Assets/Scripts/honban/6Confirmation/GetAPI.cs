using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
//using UnityEditor;

public class GetAPI : MonoBehaviour {

    private responseBody requestVisionAPI(string base64ImageData)
    {
        // 参考:https://qiita.com/jyuko/items/e6115a5dfc959f52591d

        string apiKey = "AIzaSyALq6mj-H1c2HKrXubWzhsPtUCxni_Z5_I";//APIキー
        string url = "https://vision.googleapis.com/v1/images:annotate?key=" + apiKey;

        // 送信用データを作成

        // 1.requestBodyを作成
        var requests = new requestBody();
        requests.requests = new List<AnnotateImageRequest>();

        // 2.requestBody > requestを作成
        var request = new AnnotateImageRequest();
        request.image = new Image();
        request.image.content = base64ImageData;

        // 3.requestBody > request > featureを作成
        request.features = new List<Feature>();
        var feature = new Feature();
        feature.type = FeatureType.LABEL_DETECTION.ToString();
        feature.maxResults = 10;
        request.features.Add(feature);

        requests.requests.Add(request);

        // JSONに変換
        string jsonRequestBody = JsonUtility.ToJson(requests);
        
        // ヘッダを"application/json"にして投げる
        var webRequest = new UnityWebRequest(url, "POST");
        byte[] postData = Encoding.UTF8.GetBytes(jsonRequestBody);
        webRequest.uploadHandler = new UploadHandlerRaw(postData);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        webRequest.Send();

        return JsonUtility.FromJson<responseBody>(webRequest.downloadHandler.text);
    }

    void Start()
    {
        var texture = new Texture2D(810,1440);
        texture.LoadImage(CameraReader.bytes);
        byte[] png = texture.EncodeToPNG();
        string encode = Convert.ToBase64String (png);

        var json = requestVisionAPI(encode);

        // Assetsフォルダに保存する
        var path = Application.dataPath + "/sample.txt";
        var writer = new StreamWriter (path, false); // 上書き
        writer.WriteLine (json);
        writer.Flush ();
        writer.Close ();
    }
}