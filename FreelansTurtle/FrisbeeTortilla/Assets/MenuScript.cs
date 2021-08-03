using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour
{
    private static MenuScript _instance;
    public static MenuScript Instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject[] window;
    public SaveInfo sv;

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Game()
    {
        SceneManager.LoadScene(1);

    }
    private void Start()
    {
      // PlayerPrefs.DeleteAll();
    }

    public void Next(int index)
    {



        switch (index)
        {

            case 1:
                //menu
                Cleaner();
                window[0].SetActive(true);

                break;
            case 2:
                //settings
                Cleaner();
                window[1].SetActive(true);

                break;
            case 3:
                //honour
                Cleaner();
                window[2].SetActive(true);

                break;

            case 4:
                //pop-up
                Cleaner();
                window[3].SetActive(true);

                break;

            case 5:
                //gameover
                Cleaner();
                window[4].SetActive(true);

                break;
            case 6:
                //playerChanger
                Cleaner();
                window[5].SetActive(true);

                break;
            case 7:
                //addNewPlayer
                Cleaner();
                window[6].SetActive(true);

                break;
            case 8:
                //Game
                Cleaner();
                window[7].SetActive(true);

                break;
        }

    }
    public void Cleaner()
    {

        foreach (var window in window)
        {
            window.SetActive(false);
        }
    }

    public void SetIndexPlayer(int index)
    {
        PlayerPrefs.SetInt(sv.playerIndex, index);
    }

}

