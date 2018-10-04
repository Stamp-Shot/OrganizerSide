using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //データベース、StampShot.dbに接続
        SqliteDatabase sqlDB = new SqliteDatabase("StampShot.db");

        //TODO max(id)でデータベースの中の行数を数えて管理する

        //データベース文を格納
        string selectQuery = "select * from position where id = 3";

        //文を投げてその出力結果を受け取る
        DataTable dataTable = sqlDB.ExecuteQuery(selectQuery);

      
        foreach (DataRow dr in dataTable.Rows)
        {
            //値を格納
            int id = (int)dr["id"];
            double latitude = (double)dr["latitude"];
            double longitude = (double)dr["longitude"];

            //実際に表示
            this.GetComponent<Text>().text = id.ToString()+" "+latitude.ToString()+" "+longitude.ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
