using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleQRReader : MonoBehaviour
{
    string _result = null;
    WebCamTexture _webCam;

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam) == false)
        {
            Debug.LogFormat("no camera.");
            yield break;
        }
        Debug.LogFormat("camera ok.");
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices == null || devices.Length == 0)
            yield break;
        _webCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height, 12);
        _webCam.Play();
    }

    void Update()
    {
        if (_webCam != null)
        {
            _result = QRCodeHelper.Read(_webCam);
            Debug.LogFormat("result : " + _result);
        }
    }

}