using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageReading : MonoBehaviour {

    RawImage rawimage;
    Texture2D tex;

    void Start()
    {
        tex = new Texture2D(810, 1440);
        rawimage = GetComponent<RawImage>();
        tex.LoadImage(CameraReader.bytes); //最新の写真をCameraReaderクラスから読み込む
        rawimage.texture = tex;
    }
}
