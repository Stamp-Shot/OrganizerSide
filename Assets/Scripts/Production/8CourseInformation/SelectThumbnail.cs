using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class SelectThumbnail : MonoBehaviour {

	[SerializeField]
	public GameObject obj;

	void Start () 
	{
		var JsonDirectory = Application.dataPath + "/course/spot/json/";//パス指定
		var PictureDirectory = Application.dataPath + "/course/spot/picture/";//パス指定
		
		var fileCount = Directory.GetFiles(JsonDirectory, "*.json", SearchOption.AllDirectories).Length;//指定されたフォルダ内のファイル数を数える

		string[] JsonFiles = Directory.GetFiles(JsonDirectory, "*.json");//"C:\test"以下のjsonファイルをすべて取得する
		string[] PictureFiles = Directory.GetFiles(PictureDirectory, "*.png");//"C:\test"以下のjsonファイルをすべて取得する

		var Panel = new List<GameObject>();

		//ファイルの個数分スクロースバーに追加
		for(int i=0; i<fileCount; i++)
		{
			var text = obj.GetComponentInChildren<Text>();
			var image = obj.GetComponentInChildren<RawImage>();

			var json = File.ReadAllText(JsonFiles[i]);//ファイル読み込み
			var spot = JsonUtility.FromJson<Spot>(json);//jsonからデータ読み込み

			text.text = spot.name;//表示
			image.texture = ReadPicture.ReadPng(PictureFiles[i]);//パスからpngファイルを読み込む
			
			Panel.Add(Instantiate(obj, transform, false) as GameObject);
		}
	}
}