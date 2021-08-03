using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public void Eng()
    {
        string language = "Eng";
        PlayerPrefs.SetString("Language", language);
    }

    public void De()
    {
        string language = "Deu";
        PlayerPrefs.SetString("Language", language);
    }

    public void Fr()
    {
        string language = "Fra";
        PlayerPrefs.SetString("Language", language);
    }
}