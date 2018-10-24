using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmationButtonClick : MonoBehaviour {

	public void OKClick()//OKボタンが押さえたら
	{
		PushButton.PreviousScene = "6Confirmation";
		SceneManager.LoadScene("4SpotCreateAndEdit"); //シーンを呼び出す
	}

	public void NGClick()//NGボタンが押されたら
	{
		CameraReader.transition = "6Confirmation";
		PushButton.PreviousScene = "6Confirmation";
		SceneManager.LoadScene("5Shooting"); //シーンを呼び出す
	}
}
