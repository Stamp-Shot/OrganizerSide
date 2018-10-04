using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenShotSave : MonoBehaviour
{
    GameObject Plane; //ゲームオブジェクトそのものが入る変数

    WebCamReader script; //Scriptが入る変数

    void Start()
    {
        Plane = GameObject.Find("Plane"); //Planeをオブジェクトの名前から取得して変数に格納する
        script = Plane.GetComponent<WebCamReader>(); //Planeの中にあるWebCamReaderというscriptを取得して変数に格納する
    }

    public void OnClick()//ボタンがおされたら
    {
        script.Save(); //WebCamReaderのSave()を実行
    }
}
