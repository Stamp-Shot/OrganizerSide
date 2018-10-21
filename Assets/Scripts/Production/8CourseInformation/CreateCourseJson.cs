using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System; // UnityJsonを使う場合に必要
using System.IO; // ファイル書き込みに必要

//サーバにPOSTするコース情報
[Serializable]
public class Course
{
    public string   name    = string.Empty;
    public int      spot_count = 0;
    public SpotAttributes spot_attributes;
} 

[Serializable]
public class SpotAttributes
{
    public string   name    = string.Empty;
    public float GPU_X = 0.0f;
    public float GPS_Y = 0.0f;
    public string comment = string.Empty;
} 

public class CreateCourseJson : MonoBehaviour
{
    public InputField InputCourseName;
    public InputField InputCourseDescription;

    public void OnClick()
    {
        var course = new Course();

        var directory = Application.dataPath + "/course/spot/json/";//パス指定
		var fileCount = Directory.GetFiles(directory, "*.json", SearchOption.AllDirectories).Length;//指定されたフォルダ内のファイル数を数える
		string[] files = Directory.GetFiles(directory, "*.json");//"C:\test"以下のjsonファイルをすべて取得する

        //データ入力
        course.name = InputCourseName.text; //スポット名
        course.spot_count = 8;//スポット数
        //サムネイルの画像ファイル名

        var CourseSpot = new SpotAttributes[8];
        Debug.Log(fileCount);
        for(int i=0;i<8;i++)
        {
            var json = File.ReadAllText(files[i]);//ファイル読み込み
			var ReadSpot = JsonUtility.FromJson<Spot>(json);//jsonからデータ読み込み

            CourseSpot[i] = new SpotAttributes();
            CourseSpot[i].name = ReadSpot.name;
            CourseSpot[i].GPU_X = ReadSpot.latitude;
            CourseSpot[i].GPS_Y = ReadSpot.longitude;
            CourseSpot[i].comment = ReadSpot.description;
        }

        // JSONにシリアライズ
        var Wjson = JsonUtility.ToJson(course,true);

        // jsonファイルをフォルダに保存する
        var Wpath = Application.dataPath + "/course/" + course.name + ".json";//ファイル名をspot名にしてファイル指定
        var writer = new StreamWriter (Wpath, false); // 上書き
        writer.WriteLine (Wjson);
        writer.Flush ();
        writer.Close ();

        //フォルダの名前を変更する
        Directory.Move(Application.dataPath + "/course", Application.dataPath + "/" + course.name);

        SceneManager.LoadScene("3CourseCreationHome");
    }
}
