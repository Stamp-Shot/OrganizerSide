using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



// もうPhotographyシーンの中だけで撮影・確認を済ませたほうがいいんじゃないかと考え始めたから検討して


public class WebCamReader : MonoBehaviour
{
    private int width = 800;
    private int height = 1280;
    private int fps = 30;
    WebCamTexture webcamTexture;
    public Color32[] webcamreadColor;
    private int PictureCount = 0;

    void Start()//初期設定
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
        StartCamera(); //カメラ起動
    }

    void StartCamera()//シーンが呼び出されたときに実行されるらしい
    {
        webcamTexture.Play();
    }

    public void Save()//画像を保存する
    {
        webcamreadColor = webcamTexture.GetPixels32(); //ピクセル配列を取得
        Texture2D texture = new Texture2D(webcamTexture.width, webcamTexture.height);//新規作成

        GameObject.Find("Plane").GetComponent<Renderer>().material.mainTexture = texture; //Quadを見つけてテクスチャを張り付ける

        texture.SetPixels32(webcamreadColor);//ピクセルカラー配列を設定

        var bytes = texture.EncodeToPNG();//PNGフォーマットにエンコード

        texture.Apply();//SetPixel 関数と SetPixels 関数による変更を適用


        /*
        webcamTexture.Stop(); //カメラ停止

        SceneManager.LoadScene("Confirmation");
        */



        /*--------↓画像保存しようとしたけど未完成↓------------------------------------------------------------------------------------

        string path = "";
        using (AndroidJavaClass jcEnvironment = new AndroidJavaClass("android.os.Environment"))
        using (AndroidJavaObject joExDir = jcEnvironment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory"))
        {
            path = joExDir.Call<string>("toString") + "/jp.co.cname.app/";
        }
        //フォルダがなければ作成
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        // Encode texture into PNG
        Object.Destroy(texture);

        //Write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

        //ファイル名入力
        // path += System.DateTime.Now.Ticks.ToString() + ".png";
        */
    }


}