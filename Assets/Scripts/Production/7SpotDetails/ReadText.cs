using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadText : MonoBehaviour {

	public Text name;
	public Text description;

	// Use this for initialization
	void Start () 
	{
			var path = Application.dataPath + "/Json/" + PushSpotButton.SpotName + ".json"; //現在のパス

			var json = File.ReadAllText(path);//ファイル読み込み
			var spot = JsonUtility.FromJson<Spot>(json);//jsonからデータ読み込み

			name.text = spot.name;
			description.text = spot.description;
	}
	
}
