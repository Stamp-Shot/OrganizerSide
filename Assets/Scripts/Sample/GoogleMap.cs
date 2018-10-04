using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleMap : MonoBehaviour {
    RawImage m_RawImage;

    string url = "https://maps.googleapis.com/maps/api/staticmap?center=38.082735%2C140.812027&zoom=16&size=600x600&key=AIzaSyACZEuZaYoXJCl3l-JhoXcfMpRod1XhBYo";

    IEnumerator Start()
    {
        // Start a download of the given URL
        using (WWW www = new WWW(url))
        {
            // Wait for download to complete
            yield return www;

            //Fetch the RawImage component from the GameObject
            m_RawImage = GetComponent<RawImage>();
            //Change the Texture to be the one you define in the Inspector
            m_RawImage.texture = www.texture;
        }
    }

}
