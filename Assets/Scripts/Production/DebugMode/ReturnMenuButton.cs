using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenuButton : MonoBehaviour {

	public void PushReturnMenuButton()
	{
		SceneManager.LoadScene("2Menu");
	}
}
