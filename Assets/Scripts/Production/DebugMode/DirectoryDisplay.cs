using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DirectoryDisplay : MonoBehaviour {

	public InputField Input;
	public RectTransform prefab;

	public void OnClick()
	{
		var path = Application.dataPath + Input.text;//入力場所からパスを取得

		var fileCount = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;//指定されたフォルダ内のファイル数を数える
		string[] files = Directory.GetFiles(path, "*");//"C:\test"以下の".txt"ファイルをすべて取得する

		var fileCount = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;//指定されたフォルダ内のファイル数を数える
		string[] directories = Directory.GetFiles(path, "*");//"C:\test"以下の".txt"ファイルをすべて取得する
	}
}
