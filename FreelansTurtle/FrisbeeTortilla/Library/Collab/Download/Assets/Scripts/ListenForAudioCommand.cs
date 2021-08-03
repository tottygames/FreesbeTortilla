
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenForAudioCommand : MonoBehaviour
{
 
    void Start()
    {

    }

  
    void Update()
    {
        float db = miinput.MicLoudnessinDecibels;

        if (db < 1 && db > -50f)
        {
            // InputGameManager.instance.ItsOKtoMove();
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 4);
        }

        Debug.Log("Volume is " + miinput.MicLoudness.ToString("##.#####") + ", decibels is :" + miinput.MicLoudnessinDecibels.ToString("######"));
     
    }


    float NormalizedLinearValue(float v)
    {
        float f = Mathf.InverseLerp(.000001f, .001f, v);
        return f;
    }

    float NormalizedDecibelValue(float v)
    {
        float f = Mathf.InverseLerp(-114.0f, 6f, v);
        return f;
    }
}