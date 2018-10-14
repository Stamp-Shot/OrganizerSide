using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PushSpotButton : MonoBehaviour {

	public Text text;
	string SpotName;

	public void PushAddSpotButton()
	{
		SceneManager.LoadScene("5Shooting"); //シーンを呼び出す
	}

	public void PushDescriptionButton()
	{
		SpotName = text.text;
		Debug.Log(SpotName);
	}

}
