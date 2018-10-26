using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushItemButton : MonoBehaviour {

	public void PushShotButton()
	{
		CameraReader.transition = "10ItemOption";
		CameraReader.ReturnFromCamera = "10ItemOption";
		SceneManager.LoadScene("5Shooting"); //シーンを呼び出す
	}

	public void PushReturnButton()
	{
		SceneManager.LoadScene("8CourseInformations"); //シーンを呼び出す
	}
}
