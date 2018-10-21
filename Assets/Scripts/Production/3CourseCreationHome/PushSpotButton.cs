using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PushSpotButton : MonoBehaviour {

	public Text text;
	public static string SpotName;

	public void PushAddSpotButton()
	{
		CameraReader.transition = "6Confirmation";
		SceneManager.LoadScene("5Shooting"); //シーンを呼び出す
	}

	public void PushDescriptionButton()
	{
		SpotName = text.text;
		SceneManager.LoadScene("7SpotDetails"); //シーンを呼び出す
	}

}
