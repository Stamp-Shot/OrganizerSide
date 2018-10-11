using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLocation : MonoBehaviour
{
    public static float latitude ;
    public static float longitude ;

    private float intervalTime = 0.0f;

    RawImage Map;

    string url = "https://maps.googleapis.com/maps/api/staticmap?center=";

    // Use this for initialization;
    void Start()
    {
        StartCoroutine(GetGPS());
        StartCoroutine(GetMap());
    }

    IEnumerator GetGPS() //GPSから位置情報を取得する
    {
        if (!Input.location.isEnabledByUser)//位置情報が許可されていなかったら
        {
            this.GetComponent<Text>().text = "Don't connect";
            yield break;
        }

        Input.location.Start();//はーいよーいスタート

        int maxWait = 120;


        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) //初期化が完了するまで
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1) //時間経過しすぎ
        {
            this.GetComponent<Text>().text = "Timed out";
            yield break;
        }


        if (Input.location.status == LocationServiceStatus.Failed) //読み込み失敗
        {
            this.GetComponent<Text>().text = "Unable to determine device location";
            yield break;
        }
        else//読み込みに成功したよ！やったね！
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
        }

        this.GetComponent<Text>().text = "Location:" +
        latitude + " , " + longitude; //座標表示

        Input.location.Stop(); //おわおわり

    }

    //マップを表示させるための関数
    IEnumerator GetMap()
    {
        url += latitude + "%2C" + longitude + 
        "&markers=size%3Amid%7Ccolor%3Ared%7C" + latitude + "%2C" + longitude +
        "&zoom=16&size=600x600&key=AIzaSyACZEuZaYoXJCl3l-JhoXcfMpRod1XhBYo";

        // Start a download of the given URL
        using (WWW www = new WWW(url))
        {
            // Wait for download to complete
            yield return www;

            //Fetch the RawImage component from the GameObject
            Map = this.GetComponent<RawImage>();
            //Change the Texture to be the one you define in the Inspector
            Map.texture = www.texture;
        }
    }
}


