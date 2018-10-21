using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour {

	public Text SelectText;
	public Text ThumbnailText;

	public void OnClick()
	{
		ThumbnailText.text = "サムネイル:" + SelectText.text;
	}
}
