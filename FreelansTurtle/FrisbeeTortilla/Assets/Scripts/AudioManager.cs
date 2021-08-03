using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource myAud;

    public AudioClip audioFx;


    public void PlayFx()
    {
        myAud.PlayOneShot(audioFx);
    }

}
