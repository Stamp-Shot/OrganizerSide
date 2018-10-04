using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageReading : MonoBehaviour {

    RawImage rawimage;
    Texture2D tex;
    CameraReader cr;

    public static byte[] ReadPngFile(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }

    public static Texture2D ReadPng(string path)//画像ファイルのパスを投げるとテクスチャが返ってくる
    {
        byte[] readBinary = ReadPngFile(path);

        int pos = 16; // 16バイトから開始

        int width = 0; //サイズを取得する
        for (int i = 0; i < 4; i++)
        {
            width = width * 256 + readBinary[pos++];
        }

        int height = 0;
        for (int i = 0; i < 4; i++)
        {
            height = height * 256 + readBinary[pos++];
        }


        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(readBinary);

        return texture;
    }


    // Use this for initialization 
    void Start()
    {
        tex = new Texture2D(810, 1440);
        string path = Application.dataPath + "/test.png"; //現在のパス

        rawimage = GetComponent<RawImage>();
        //rawimage.texture = ReadPng(path);
        tex.LoadImage(CameraReader.bytes);
        rawimage.texture = tex;
    }
}
