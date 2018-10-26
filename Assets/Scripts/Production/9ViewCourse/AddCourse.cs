using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class AddCourse : MonoBehaviour {

	[SerializeField]
	public GameObject obj;

	void Start () 
	{
		var directory = "/sdcard/StampShot/";//パス指定
		//"/sdcard/Json";
		var fileCount = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories).Length;//指定されたフォルダ内のファイル数を数える
		string[] files = Directory.GetDirectories(directory, "*");//"C:\test"以下のjsonファイルをすべて取得する

		var Panel = new List<GameObject>();

		//ファイルの個数分スクロースバーに追加
		for(int i=0; i<fileCount; i++)
		{
			var text = obj.GetComponentInChildren<Text>();
			Debug.Log(files[i]);
			Panel.Add(Instantiate(obj, transform, false) as GameObject);
		}
	}
}