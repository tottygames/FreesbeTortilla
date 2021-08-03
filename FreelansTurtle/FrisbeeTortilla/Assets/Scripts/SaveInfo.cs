using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInfo : MonoBehaviour
{
   public Info[] profiles;
   public string playerIndex;
    private void Start()
    {
        for(int i = 0; i < profiles.Length; i++)
        {
            profiles[i].score = PlayerPrefs.GetInt(profiles[i].scoreKey);
        }
    }
}
