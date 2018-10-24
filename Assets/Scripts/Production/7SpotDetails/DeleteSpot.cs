using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteSpot : MonoBehaviour {

	public void PushDeleteButton()
	{
		File.Delete(ReadTextAndMap.path + "/json/" +PushSpotButton.SpotName + ".json");
		File.Delete(ReadTextAndMap.path + "/json/API/" + PushSpotButton.SpotName + "API.json");
		File.Delete(ReadTextAndMap.path + "/picture/" +PushSpotButton.SpotName + ".png");
		PushButton.PreviousScene = "7SpotDetails";
		SceneManager.LoadScene("3CourseCreationHome");
	}
}
