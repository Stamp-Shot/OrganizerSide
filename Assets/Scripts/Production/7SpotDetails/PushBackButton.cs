using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBackButton: MonoBehaviour {

	public void PushbackButton()
	{
		PushButton.PreviousScene = "7SpotDetails";
		SceneManager.LoadScene("3CourseCreationHome");
	}
}
