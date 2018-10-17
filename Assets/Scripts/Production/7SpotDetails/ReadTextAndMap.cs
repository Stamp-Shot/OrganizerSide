using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadTextAndMap : MonoBehaviour {

	public Text name;
	public Text description;

	public RawImage Map;

    string url = "https://maps.googleapis.com/maps/api/staticmap?center=";

	float latitude;
	float longitude;

	// Use this for initialization
	void Start () 
	{
			var path = Application.dataPath + "/course/spot/json/" + PushSpotButton.SpotName + ".json"; //現在のパス

			var json = File.ReadAllText(path);//ファイル読み込み
			var spot = JsonUtility.FromJson<Spot>(json);//jsonからデータ読み込み

			name.text = spot.name;
			description.text = spot.description;

			latitude = spot.latitude;
			longitude = spot.longitude;

			StartCoroutine(GetMap());
	}

	    //マップを表示させるための関数
    IEnumerator GetMap()
    {
        url += latitude + "%2C" + longitude + 
        "&markers=size%3Amid%7Ccolor%3Ared%7C" + latitude + "%2C" + longitude +
        "&zoom=18&size=600x600&key=AIzaSyACZEuZaYoXJCl3l-JhoXcfMpRod1XhBYo";

        // Start a download of the given URL
        using (WWW www = new WWW(url))
        {
            // Wait for download to complete
            yield return www;
            //Change the Texture to be the one you define in the Inspector
            Map.texture = www.texture;
        }
    }
	
}
