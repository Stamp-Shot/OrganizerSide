using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnHomeButton : MonoBehaviour {

	public void PushReturnButton()
	{
		SceneManager.LoadScene("2Menu"); //シーンを呼び出す
	}
}
