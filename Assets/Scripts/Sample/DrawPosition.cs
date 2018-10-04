using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawPosition : MonoBehaviour {
    public int ListNumber = 1;

    private string name;

    // Use this for initialization
    void Start()
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
            name = (string)dr["name"];
        }

        this.GetComponent<Text>().text = name;
    }
}
