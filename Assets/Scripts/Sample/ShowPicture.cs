using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class ShowPicture : MonoBehaviour {

    private int width = 800;
    private int height = 1280;
    private int fps = 30;
    WebCamTexture readedTexture;
    WebCamReader readed;
    public Color32[] readedColor;

	void Start ()
    {
        readed = new WebCamReader();
        WebCamDevice[] readeddevices = WebCamTexture.devices;
        readedTexture = new WebCamTexture(readeddevices[0].name, this.width, this.height, this.fps);
        GetComponent<Renderer>().material.mainTexture = readedTexture;

        this.Show();
    }

    public void Show()
    {
        readedColor = readed.webcamreadColor;
        Texture2D texture = new Texture2D(readedTexture.width, readedTexture.height);//新規作成

        GameObject.Find("Quad").GetComponent<Renderer>().material.mainTexture = texture;

        texture.SetPixels32(readedColor);//ピクセルカラー配列を設定f

        var bytes = texture.EncodeToPNG();//PNGフォーマットにエンコード

        texture.Apply();//SetPixel 関数と SetPixels 関数による変更を適用
    }
}
