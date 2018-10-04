using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToThePhotography : MonoBehaviour {

    public void OnClick()//ボタンがおされたら
    {
        SceneManager.LoadScene("Photography"); //Photographyシーンを呼び出す
    }
}
