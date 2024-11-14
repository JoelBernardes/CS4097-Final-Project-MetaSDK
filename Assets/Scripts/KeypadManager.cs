using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    public TMP_Text textDisplay;
    void Start()
    {
        textDisplay.text = "";
    }

    public void UpdateText(string key)
    {
        textDisplay.text += key;
    }

    public void DeleteText()
    {
        if (textDisplay.text.Length >= 1)
        {
            textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 1);
        }
    }

    public void ClearText()
    {
        textDisplay.text = "";
    }
}
