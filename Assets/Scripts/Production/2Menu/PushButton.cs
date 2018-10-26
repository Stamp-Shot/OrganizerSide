using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour {
	public static string PreviousScene;//前にいたシーン

	public void PushOptionButton()
	{
		SceneManager.LoadScene("DebugMode"); 
	}

	public void PushNewCourseCreateButton()
	{
		SceneManager.LoadScene("3CourseCreationHome");
	}

	public void PushCourseViewButton()
	{
		SceneManager.LoadScene("9ViewCourse");
	}

	public void PushItemExchangeButton()
	{
		SceneManager.LoadScene("12QRCodeReader");
	}

	public void PushAccountRegistrationButton()
	{
		SceneManager.LoadScene("11AccountRegistration");
	}

	public void PushReturnBUtton()
	{
		SceneManager.LoadScene("1Start");
	}
}
