using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadElement : MonoBehaviour {

	public RectTransform prefab = null;

	// Use this for initialization
	void Start () 
	{
		var path = Application.dataPath + "/course/spot/json/API/" + PushSpotButton.SpotName + "API.json"; //現在のパス
		var json = File.ReadAllText(path);//ファイル読み込み
		var element = JsonUtility.FromJson<SpotElement[]>(json);//jsonからデータ読み込み
		
		for(int i=0;i<element.Length;i++)
        {
            var elem = GameObject.Instantiate(prefab) as RectTransform;
			elem.SetParent(transform, false);

			var text = elem.GetComponentInChildren<Text>();
			text.text = element[i].name +"\n" + element[i].score.ToString();
        }
	}
}