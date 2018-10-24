using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class CameraReader : MonoBehaviour
{
    private int width = 810;
    private int height = 1440;
    private int fps = 30;
    WebCamTexture webcamTexture;
    public static byte[] bytes;
    public static string transition;//どのSceneに遷移するかを決める
    public Color32[] webcamreadColor;

    private int PictureCount = 0;


    void Start()//初期設定
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
        GetComponent<Renderer>().material.mainTexture = webcamTexture; //ゲームオブジェクトにウェブカメラを適用

        //TODO 時間があればここにカメラの向き変更を適用するコードを書きたい

        webcamTexture.Play(); //カメラ起動
    }

    public void Save()//画像を保存する
    {
        webcamreadColor = webcamTexture.GetPixels32(); //ピクセル配列を取得
        Texture2D texture = new Texture2D(webcamTexture.width, webcamTexture.height);//新規作成

        texture.SetPixels32(webcamreadColor);//ピクセルカラー配列を設定

        bytes = texture.EncodeToPNG();//PNGフォーマットにエンコード

        texture.Apply();//SetPixel 関数と SetPixels 関数による変更を適用

        webcamTexture.Stop(); //カメラ停止

        PushButton.PreviousScene = "5Shooting";
        SceneManager.LoadScene(transition); //シーンを呼び出す

    }
}