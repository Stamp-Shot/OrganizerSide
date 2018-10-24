using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SampleQRReader : MonoBehaviour
{
    string result = null;
    WebCamTexture webCam;
    public RawImage rawImage;

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
        webCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height, 30);
        rawImage.texture  = webCam;
        webCam.Play();
    }

    void Update()
    {
        if (webCam != null)
        {
            result = QRCodeHelper.Read(webCam);

            if(result != "error")
            {
                webCam.Stop();
                Debug.LogFormat("result : " + result);
                PushButton.PreviousScene = "12QRCodeReader";
                SceneManager.LoadScene("13ItemExchange");
            }
        }
    }

}