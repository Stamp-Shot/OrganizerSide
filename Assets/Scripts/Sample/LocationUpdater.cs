using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LocationUpdater : MonoBehaviour
{ 
    private float intervalTime = 0.0f;

    void Update()
    {
        //毎フレーム読んでると処理が重くなるので、3秒毎に更新
        intervalTime += Time.deltaTime;
        if (intervalTime >= 3.0f)
        {
            StartCoroutine(GetGPS());
            intervalTime = 0.0f;
        }
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
            this.GetComponent<Text>().text = "Location:\n" +
                  Input.location.lastData.latitude + "\n" +
                  Input.location.lastData.longitude;
        }
        
        Input.location.Stop(); //おわおわり
    }
    
}