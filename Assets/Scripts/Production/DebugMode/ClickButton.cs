using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour {

    GameObject content; //ゲームオブジェクトそのものが入る変数

    DirectoryDisplay script; //Scriptが入る変数

    void Start()
    {
        content = GameObject.Find("Content"); //contentをオブジェクトの名前から取得して変数に格納する
        script = content.GetComponent<DirectoryDisplay>(); //contentの中にあるDirectoryDisplayというscriptを取得して変数に格納する
    }

    public void OnClick()//ボタンがおされたら
    {
        script.ShowDirectory(); //実行
    }
}
