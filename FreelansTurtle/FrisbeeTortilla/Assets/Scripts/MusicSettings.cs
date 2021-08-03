using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{


    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;


    public GameObject[] texts;
    private int index = 0;


    public AudioManager AM;

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("IndexOfMusic");


        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
        }
        else
        {
            Load();
        }

        AudioListener.pause = muted;
    }

    // Update is called once per frame
    void Update()
    { 
        switch (index)
        {
            case 0:
                texts[0].SetActive(true);
                texts[1].SetActive(false);
                PlayerPrefs.SetInt("IndexOfMusic", index);
                break;
            case 1:
                texts[0].SetActive(false);
                texts[1].SetActive(true);
                PlayerPrefs.SetInt("IndexOfMusic" , index);
                break;
        }
    }

    public void Plus()
    {
        if(index == 0)
            index++;


        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        Save();
    }

    public void Minus()
    {
        if(index == 1)
            index--;


        if (muted== true)
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
    }


    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted")==1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
