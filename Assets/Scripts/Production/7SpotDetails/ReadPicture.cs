using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadPicture : MonoBehaviour {

    public RawImage rawimage;

    public static byte[] ReadPngFile(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }

    //画像ファイルのパスを投げるとテクスチャが返ってくる
    public static Texture2D ReadPng(string path)
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


    
    void Start()
    {
		var path = "/sdcard/StampShot/course/spot/picture/" + PushSpotButton.SpotName + ".png"; //現在のパス
        rawimage.texture = ReadPng(path);//パスからpngファイルを読み込む
    }
}