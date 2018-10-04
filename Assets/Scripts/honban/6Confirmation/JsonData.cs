using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // UnityJsonを使う場合に必要
using System.IO; // ファイル書き込みに必要

[Serializable]
public class spot
{
    [SerializeField]
    public location[]   location   = null;
}

[Serializable]
public class location
{
    /* 
    [SerializeField]
    public string   name    = string.Empty;
    */
    [SerializeField]
    public float      latitude    = 0.0f;
    [SerializeField]
    public float     longitude  = 0.0f;

} 

public class JsonData : MonoBehaviour
{
    public void OnClick()
    {
        var data = new spot();
        var location = new location ();

        location.latitude = 5.0f;
        location.longitude = 7.0f;

        // JSONにシリアライズ
        var json = JsonUtility.ToJson (data);

        // Assetsフォルダに保存する
        var path = Application.dataPath + "/sample.txt";
        var writer = new StreamWriter (path, false); // 上書き
        writer.WriteLine (json);
        writer.Flush ();
        writer.Close ();
    }
}