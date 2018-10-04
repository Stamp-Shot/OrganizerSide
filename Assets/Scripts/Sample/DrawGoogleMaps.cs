using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawGoogleMaps : MonoBehaviour {

    RawImage m_RawImage;

    public int ListNumber = 1;
    private double latitude = 0;
    private double longitude = 0;

    string url = "http://maps.googleapis.com/maps/api/staticmap?center=";

    // Use this for initialization
    IEnumerator Start()
    {
        //データベース、StampShot.dbに接続
        SqliteDatabase sqlDB = new SqliteDatabase("StampShot.db");

        //データベース文を格納
        string selectQuery = "select * from position where id = " + ListNumber;

        //文を投げてその出力結果を受け取る
        DataTable dataTable = sqlDB.ExecuteQuery(selectQuery);

        foreach (DataRow dr in dataTable.Rows)
        {
            //値を格納
            latitude = (double)dr["latitude"];
            longitude = (double)dr["longitude"];
        }

        //URL作成
        url += latitude.ToString() + "," + longitude.ToString() + "&zoom=16&size=600x600&key=AIzaSyACZEuZaYoXJCl3l-JhoXcfMpRod1XhBYo";


        // Start a download of the given URL
        using (WWW www = new WWW(url))
        {
            // Wait for download to complete
            yield return www;

            //Fetch the RawImage component from the GameObject
            m_RawImage = GetComponent<RawImage>();
            //Change the Texture to be the one you define in the Inspector
            m_RawImage.texture = www.texture;
        }
    }
}
