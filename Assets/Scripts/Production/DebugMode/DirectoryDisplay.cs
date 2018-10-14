using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DirectoryDisplay : MonoBehaviour {

	public InputField Input;
	public RectTransform prefab = null;

	public void ShowDirectory()
	{
		var path = "/storage/emulated/0/"+ Input.text;//入力場所からパスを取得

		var fileCount = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;//指定されたフォルダ内のファイル数を数える
		string[] files = Directory.GetFiles(path, "*");//"C:\test"以下の".txt"ファイルをすべて取得する

		var directoryCount = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).Length;//指定されたフォルダ内のファイル数を数える
		string[] directories = Directory.GetDirectories(path, "*");//"C:\test"以下の".txt"ファイルをすべて取得する

		for(int i=0; i<fileCount; i++)
		{
			var item = GameObject.Instantiate(prefab) as RectTransform;
			item.SetParent(transform, false);

			var text = item.GetComponentInChildren<Text>();
			text.text = files[i];
		}

		for(int i=0; i<directoryCount; i++)
		{
			var item = GameObject.Instantiate(prefab) as RectTransform;
			item.SetParent(transform, false);

			var text = item.GetComponentInChildren<Text>();
			text.text = "item:" + directories[i];
		}
	}
}
