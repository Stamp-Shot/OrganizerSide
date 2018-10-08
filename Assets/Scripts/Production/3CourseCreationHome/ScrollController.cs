using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;


public class ScrollController : MonoBehaviour {

	[SerializeField]
	RectTransform prefab = null;
	public GameObject obj;

	void Start () 
	{
		var directory = @"C:\Users\gobou\OneDrive\ドキュメント\Unity\StampShot\Assets/Json";//パス指定
		var fileCount = Directory.GetFiles(directory, "*.json", SearchOption.AllDirectories).Length;//指定されたフォルダ内のファイル数を数える

		//"C:\test"以下の".txt"ファイルをすべて取得する
		string[] files = Directory.GetFiles(directory, "*.json");

		//ファイルの個数分スクロースバーに追加
		for(int i=0; i<fileCount; i++)
		{
			//var item = GameObject.Instantiate(prefab) as RectTransform;
			//item.SetParent(transform, false);

			


			var text = obj.GetComponentInChildren<Text>();

			var json = File.ReadAllText(files[i]);//ファイル読み込み
			var spot = JsonUtility.FromJson<Spot>(json);//jsonからデータ読み込み

			text.text = spot.name;//表示

			Instantiate(obj, transform, false);
		}
	}
}