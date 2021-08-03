using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    private static ScoreSystem _instance;
    public static ScoreSystem Instance
    {
        get
        {
            return _instance;
        }
    }



    public Text score,highScore ,scorePerRound;
    public int scoreCounter, highScoreCounter;

    public float value = 0;
    public float speed = 5;
    public int add;

    public int playerIndex;
    public SaveInfo sv;

    private void Awake()
    {
        _instance = this;

        
    }

    private void Start()
    {
        add = 1;
        
    }

    void Update()
    {
    
        playerIndex = PlayerPrefs.GetInt(sv.playerIndex);
        switch (playerIndex)
        {
            case 0:
                if (PlayerPrefs.HasKey(sv.profiles[playerIndex].scoreKey))
                {
                    highScoreCounter = PlayerPrefs.GetInt(sv.profiles[playerIndex].scoreKey);
                }
                break;
            case 1:
                if (PlayerPrefs.HasKey(sv.profiles[playerIndex].scoreKey))
                {
                    highScoreCounter = PlayerPrefs.GetInt(sv.profiles[playerIndex].scoreKey);
                }
                break;
            case 2:
                if (PlayerPrefs.HasKey(sv.profiles[playerIndex].scoreKey))
                {
                    highScoreCounter = PlayerPrefs.GetInt(sv.profiles[playerIndex].scoreKey);
                }
                break;
            case 3:
                if (PlayerPrefs.HasKey(sv.profiles[playerIndex].scoreKey))
                {
                    highScoreCounter = PlayerPrefs.GetInt(sv.profiles[playerIndex].scoreKey);
                }
                break;
            case 4:
                if (PlayerPrefs.HasKey(sv.profiles[playerIndex].scoreKey))
                {
                    highScoreCounter = PlayerPrefs.GetInt(sv.profiles[playerIndex].scoreKey);
                }
                break;
            case 5:
                if (PlayerPrefs.HasKey(sv.profiles[playerIndex].scoreKey))
                {
                    highScoreCounter = PlayerPrefs.GetInt(sv.profiles[playerIndex].scoreKey);
                }
                break;
            case 6:
                if (PlayerPrefs.HasKey(sv.profiles[playerIndex].scoreKey))
                {
                    highScoreCounter = PlayerPrefs.GetInt(sv.profiles[playerIndex].scoreKey);
                }
                break;
            case 7:
                if (PlayerPrefs.HasKey(sv.profiles[playerIndex].scoreKey))
                {
                    highScoreCounter = PlayerPrefs.GetInt(sv.profiles[playerIndex].scoreKey);
                }
                break;
        }
        score.text = scoreCounter.ToString() + "m";
        scorePerRound.text = score.text;
        highScore.text = highScoreCounter.ToString() + "m";
    }

    public void AddScore()
    {
      
        scoreCounter += add;
        HighScore();
      
    }
    public void UpScore()
    {
        
        scoreCounter += 4;
        HighScore();

    }

    public void HighScore()
    {
        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;
        }
        switch (playerIndex)
        {
            case 0:
                PlayerPrefs.SetInt(sv.profiles[playerIndex].scoreKey , highScoreCounter);
                break;
            case 1:
                PlayerPrefs.SetInt(sv.profiles[playerIndex].scoreKey, highScoreCounter);
                break;
            case 2:
                PlayerPrefs.SetInt(sv.profiles[playerIndex].scoreKey, highScoreCounter);
                break;
            case 3:
                PlayerPrefs.SetInt(sv.profiles[playerIndex].scoreKey, highScoreCounter);
                break;
            case 4:
                PlayerPrefs.SetInt(sv.profiles[playerIndex].scoreKey, highScoreCounter);
                break;
            case 5:
                PlayerPrefs.SetInt(sv.profiles[playerIndex].scoreKey, highScoreCounter);
                break;
            case 6:
                PlayerPrefs.SetInt(sv.profiles[playerIndex].scoreKey, highScoreCounter);
                break;
            case 7:
                PlayerPrefs.SetInt(sv.profiles[playerIndex].scoreKey, highScoreCounter);
                break;
        }
    }

    public void ResetScore()
    {
        scoreCounter = 0;
    }
}