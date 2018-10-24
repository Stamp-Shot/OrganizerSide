using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class ScrollController : MonoBehaviour {

	[SerializeField]
	public GameObject obj;

	void Start () 
	{
		var directory = "/sdcard/StampShot/course/spot/json/";//パス指定
		var fileCount = Directory.GetFiles(directory, "*.json", SearchOption.AllDirectories).Length;//指定されたフォルダ内のファイル数を数える
		string[] files = Directory.GetFiles(directory, "*.json");//"C:\test"以下のjsonファイルをすべて取得する

		var Panel = new List<GameObject>();

		//ファイルの個数分スクロースバーに追加
		for(int i=0; i<fileCount; i++)
		{
			var text = obj.GetComponentInChildren<Text>();

			var json = File.ReadAllText(files[i]);//ファイル読み込み
			var spot = JsonUtility.FromJson<Spot>(json);//jsonからデータ読み込み

			text.text = spot.name;//表示

			Panel.Add(Instantiate(obj, transform, false) as GameObject);
		}
	}
}