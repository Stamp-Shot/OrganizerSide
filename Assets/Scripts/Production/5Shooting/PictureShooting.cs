using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureShooting : MonoBehaviour
{
    GameObject Quad; //ゲームオブジェクトそのものが入る変数

    CameraReader script; //Scriptが入る変数

    void Start()
    {
        Quad = GameObject.Find("Quad"); //Quadをオブジェクトの名前から取得して変数に格納する
        script = Quad.GetComponent<CameraReader>(); //Quadの中にあるWebCamReaderというscriptを取得して変数に格納する
    }

    public void OnClick()//ボタンがおされたら
    {
        script.Save(); //CameraReaderのSave()を実行
    }
}
