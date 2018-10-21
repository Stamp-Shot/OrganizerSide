using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShotPicture : MonoBehaviour {

	public void OnClick()
	{
		CameraReader.transition = "6Confirmation";
		SceneManager.LoadScene("5Shooting"); //シーンを呼び出す
	}
}
