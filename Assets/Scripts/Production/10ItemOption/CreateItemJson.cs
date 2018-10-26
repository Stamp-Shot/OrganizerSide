using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System; // UnityJsonを使う場合に必要
using System.IO; // ファイル書き込みに必要s

public class CreateItemJson : MonoBehaviour {

	public InputField InputItemName;
	public InputField InputItemDescription;
	public InputField InputItemPlace;

	[Serializable]
	public class CourseItem
	{
   		public string   name    = string.Empty;
    	public string   description    = string.Empty;
    	public string   place  = string.Empty;
	} 


	public void CreateButtonPush() 
	{
		var item = new CourseItem();

        //データ入力
    	item.name = InputItemName.text; //賞品名
        item.description = InputItemDescription.text; //賞品の説明
        item.place = InputItemPlace.text; //受け渡し場所

        // JSONにシリアライズ
        var json = JsonUtility.ToJson (item,true);

        // jsonファイルをフォルダに保存する
        var path = "/sdcard/StampShot/course/item/" + item.name + ".json";//ファイル名をspot名にしてファイル指定
        var writer = new StreamWriter (path, false); // 上書き
        writer.WriteLine (json);
        writer.Flush ();
        writer.Close ();

        //撮影した写真をpng形式で保存
        File.WriteAllBytes("/sdcard/StampShot/course/item/" + item.name + ".png",CameraReader.bytes);

        SceneManager.LoadScene("2Menu");
	}
	
}
