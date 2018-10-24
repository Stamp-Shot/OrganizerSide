using UnityEngine;
using UnityEngine.UI; 
using System.Collections.Generic;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Text;

public class GetAPI : MonoBehaviour {


    public RectTransform prefab = null;


	// Use this for initialization
	void Start () 
    {
        var buffByte = CameraReader.bytes;//元画像取得
        var annotationsData = APIFunction.RequestVisionAPI(Convert.ToBase64String(buffByte));//画像を投げて結果を受け取る

        var list1 = new List<string>();
        var list2 = new List<float>();
        
        foreach (var item in annotationsData)
        {
            //リストに追加
            list1.Add(item.description);
            list2.Add(item.score);
        }

        SpotElement[] spoele = new SpotElement[list1.Count];

        //配列にぶち込む
        for(int i=0;i<list1.Count;i++)
        {
            spoele[i] = new SpotElement();            

            spoele[i].name = list1[i];
            spoele[i].score = list2[i];

            var elem = GameObject.Instantiate(prefab) as RectTransform;
			elem.SetParent(transform, false);

			var text = elem.GetComponentInChildren<Text>();
			text.text = list1[i] +"\n" + list2[i].ToString();
        }

        // JSONにシリアライズ
        var json = JsonHelper.ToJson <SpotElement>(spoele,true);

        // フォルダに保存する
        var path = "/sdcard/StampShot/course/spot/json/API/testAPI.json";//ファイル指定
        var writer = new StreamWriter (path, false); // 上書き
        writer.WriteLine (json);
        writer.Flush ();
        writer.Close ();
	}
}

//判定関係
public class CheckFunction
{
    //1. 元のデータから要らない部分を捨てる
    //2. 上から何個か取る
    //3. 同じ要素があったらtrue

    //1. 元のデータから要らない部分を捨てる
    public static EntityAnnotation[] removeAnnotation(EntityAnnotation[] entityAnnotations)
    {
        string[] blackList = {
            "sky",
            "nature",
            "cloud",
            "tree",
            "grassland",
            "horizon",
            "reflection",
            "ecosystem",
            "vegetation",
            "atomosphere",
            "plant"
        };
        var retAnnotations = new List<EntityAnnotation>();

        foreach (var annotation in entityAnnotations)
        {
            var flag = true;
            foreach (var black in blackList)
            {
                if (annotation.description == black)
                {
                    flag = false;
                    break;
                }
            }

            if(flag){
                    retAnnotations.Add(annotation);
            }
        }

        return retAnnotations.ToArray();
    }

    //2. 上から三つ取る 使わない？
    private EntityAnnotation[] pickUpTopThree(EntityAnnotation[] entityAnnotations)
    {
        const int elementCount = 3;

        var retAnnotations = new List<EntityAnnotation>();

        for (int i = 0; i < elementCount; i++)
        {
            retAnnotations.Add(entityAnnotations[i]);
        }

        return retAnnotations.ToArray();
    }

    //3-1. 同じ要素があったらtrue
    private bool checkSameAnnotation(EntityAnnotation[] originData, EntityAnnotation[] compareData)
    {
        foreach (var item1 in originData)
        {
            foreach (var item2 in compareData)
            {
                if (item1.description == item2.description)
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    //使うやつ
    public bool checkMaster(EntityAnnotation[] originData, EntityAnnotation[] compareData)
    {
        var originBuffer = removeAnnotation(originData);
        var compareBuffer = removeAnnotation(compareData);
        return checkSameAnnotation(originBuffer, compareBuffer);
    }
}

//API通信関係
public class APIFunction
{
    /// <summary>
    /// 画像データを与えるとGoogleCloudVisionでラベル検知したやつを返す。
    /// </summary>
    /// <param name="imageData"></param>
    /// <returns></returns>
    public static EntityAnnotation[] RequestVisionAPI(string base64String)
    {
        // 参考:https://qiita.com/jyuko/items/e6115a5dfc959f52591d

        string apiKey = "AIzaSyAQe-ZtCVwWx0xIco4b9U3dpbk83MoLv_c";
        string url = "https://vision.googleapis.com/v1/images:annotate?key=" + apiKey;

        // 送信用データを作成

        // 1.requestBodyを作成
        var requests = new requestBody();
        requests.requests = new List<AnnotateImageRequest>();

        // 2.requestBody > requestを作成
        var request = new AnnotateImageRequest();
        request.image = new Image();
        request.image.content = base64String;

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

        webRequest.SendWebRequest();
        // 受信するまで待機
        while (!webRequest.isDone)
        {
        }

        var buff = JsonUtility.FromJson<responseBody>(webRequest.downloadHandler.text);
        return CheckFunction.removeAnnotation(buff.responses[0].labelAnnotations.ToArray());
    }
}