using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class SendData : MonoBehaviour
{
    string str;
    public InputField inputField;

    public Text text;

    public void OnClick()
    {
        SaveText();
    }


    public void SaveText()
    {
        str = inputField.text;

        text.text = str;

        inputField.text = "";
    }

}
