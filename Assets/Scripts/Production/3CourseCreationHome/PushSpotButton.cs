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
		PushButton.PreviousScene = "3COurseCreationHome";
		SceneManager.LoadScene("5Shooting"); //シーンを呼び出す
	}

	public void PushDescriptionButton()
	{
		SpotName = text.text;
		PushButton.PreviousScene = "3COurseCreationHome";
		SceneManager.LoadScene("7SpotDetails"); //シーンを呼び出す
	}

	public void PushFinishButton()
	{
		PushButton.PreviousScene = "3COurseCreationHome";
		SceneManager.LoadScene("8CourseInformation"); //シーンを呼び出す
	}
}
