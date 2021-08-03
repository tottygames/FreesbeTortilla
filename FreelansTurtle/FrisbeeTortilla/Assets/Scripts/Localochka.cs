using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Localochka : MonoBehaviour
{

    public GameObject[] texts;

    public int idB;

    public string language;
    Text text;

    public string textDeu;
    public string textEng;
    public string textFra;

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        language = PlayerPrefs.GetString("Language");

        if (language == "" || language == "Eng")
        {
            text.text = textEng;
        }
        else if (language == "Deu")
        {
            text.text = textDeu;
        }
        else if (language == "Fra")
        {
            text.text = textFra;
        }
    }






}
