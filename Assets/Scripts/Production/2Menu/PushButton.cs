using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour {

	public void PushOptionButton()
	{
		SceneManager.LoadScene("DebugMode"); 
	}

	public void PushNewCourseCreateButton()
	{
		SceneManager.LoadScene("3CourseCreationHome");
	}
}
