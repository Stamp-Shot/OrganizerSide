using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour {
	public static string PreviousScene;//前にいたシーン

	public void PushOptionButton()
	{
		PreviousScene = "2Menu";
		SceneManager.LoadScene("DebugMode"); 
	}

	public void PushNewCourseCreateButton()
	{
		PreviousScene = "2Menu";
		SceneManager.LoadScene("3CourseCreationHome");
	}

	public void PushItemExchangeButton()
	{
		PreviousScene = "2Menu";
		SceneManager.LoadScene("12QRCodeReader");
	}

	public void PushAccountRegistrationButton()
	{
		PreviousScene = "2Menu";
		SceneManager.LoadScene("11AccountRegistration");
	}

	public void PushReturnBUtton()
	{
		SceneManager.LoadScene(PreviousScene);
	}
}
