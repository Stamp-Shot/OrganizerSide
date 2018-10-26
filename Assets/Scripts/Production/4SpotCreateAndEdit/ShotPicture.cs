using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShotPicture : MonoBehaviour {

	public void OnClick()
	{
		CameraReader.transition = "6Confirmation";
		CameraReader.ReturnFromCamera = "4SpotCreateAndEdit";
		SceneManager.LoadScene("5Shooting"); //シーンを呼び出す
	}

	public void PushReturnButton()
	{
		SceneManager.LoadScene("6Confirmation"); //シーンを呼び出す
	}
}
