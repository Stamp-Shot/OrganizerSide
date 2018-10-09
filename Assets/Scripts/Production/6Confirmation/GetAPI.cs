using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;
using System.Text;

public class GetAPI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //var sendTexture = new Texture2D(Screen.width, Screen.height);
        //var buffByte = sendTexture.EncodeToJPG();
        var buffByte = CameraReader.bytes;
        var annotationsData = TransAPI.RequestVisionAPI(Convert.ToBase64String(buffByte));
        foreach (var item1 in annotationsData.responses)
        {
            foreach (var item2 in item1.labelAnnotations)
            {
                Debug.Log(item2.description);
                Debug.Log(item2.score);
            }
        }
	}

    // Update is called once per frame
    void Update() {

    }
}

//判定関係
public class CheckFunction
{
    //上から三つを抽出
    private static EntityAnnotation[] GetTop3(responseBody annotations)
    {
        var retAnnotations = new List<EntityAnnotation>();

        for (int i = 0; i < 3; i++)
        {
            retAnnotations.Add(annotations.responses[0].labelAnnotations[i]);
        }

        return retAnnotations.ToArray();
    }

    //同じ要素を取る
    private static EntityAnnotation[] GetSameAnnotations(EntityAnnotation[] originData, responseBody fromData)
    {
        var retAnnotations = new List<EntityAnnotation>();

        for (int i = 0; i < 3; i++)
        {
            foreach (var item in fromData.responses[0].labelAnnotations)
            {
                if (item.description == originData[i].description)
                {
                    retAnnotations.Add(item);
                }
            }

            //例外処理を取らないといけない
            //if (retAnnotations[i] == null)
            //{
            //    return 
            //}
        }

        return retAnnotations.ToArray();
    }

    //比に変換
    private static EntityAnnotation[] ConvertToRatio(EntityAnnotation[] annotation)
    {
        var denominator = new float();
        denominator = 0;

        foreach (var item in annotation)
        {
            if (denominator == 0 || denominator < item.score)
            {
                denominator = item.score;
            }
        }

        foreach (var item in annotation)
        {
            item.score /= denominator;
        }

        return annotation;
    }

    //比の差を取って合計
    private static float TakeDifferenceSum(EntityAnnotation[] originData, EntityAnnotation[] fromData)
    {
        var retDifference = new float();
        for (int i = 0; i < originData.Length; i++)
        {
            retDifference += originData[i].score - fromData[i].score;
        }

        return retDifference;
    }

    //一致判定を取る
    public static bool CheckDifference(responseBody originData, responseBody fromData)
    {
        var buffOrigin = GetTop3(originData);
        var buffFrom = GetSameAnnotations(buffOrigin, fromData);
        buffOrigin = ConvertToRatio(buffOrigin);
        buffFrom = ConvertToRatio(buffFrom);

        var checkResult = TakeDifferenceSum(buffOrigin, buffFrom);

        //判定式
        var limit = 10;
        if (checkResult < limit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}

//API通信関係
public class TransAPI
{
    // 除外するやつ
    public static EntityAnnotation[] RemoveAttributeData(responseBody originData, string[] blackList)
    {
        var retAnnotations = new List<EntityAnnotation>();

        // 画像ごと
        foreach (var item1 in originData.responses)
        {
            // 属性ごと
            foreach (var item2 in item1.labelAnnotations)
            {
                // ブラックリストと一致してたら追加しない
                if (!CheckRemove(item1.labelAnnotations.ToArray(), blackList))
                {
                    retAnnotations.Add(item2);
                }
            }
        }

        return retAnnotations.ToArray();
    }

    // 除外するやつを判定するやつ
    private static bool CheckRemove(EntityAnnotation[] annotations, string[] blackList)
    {
        foreach (var annotation in annotations)
        {
            foreach (var black in blackList)
            {
                if (annotation.description == black)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// 画像データを与えるとGoogleCloudVisionでラベル検知したやつを返す。
    /// </summary>
    /// <param name="imageData"></param>
    /// <returns></returns>
    public static responseBody RequestVisionAPI(string base64String)
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
            Debug.Log("Hello World");
        }

        return JsonUtility.FromJson<responseBody>(webRequest.downloadHandler.text);
    }
}