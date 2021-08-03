using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Info
{
    public string key;
    public string imgKey;
    public string scoreKey;
    public int score;

    public Info(string key, string imgKey,  string scoreKey , string playerIndex , int score)
    {
        this.key = key;
        this.imgKey = imgKey;
        this.scoreKey = scoreKey;
        this.score = score;
        
    }
}
