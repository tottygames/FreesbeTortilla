
using UnityEngine;
using System.Collections;


public class MicInput : MonoBehaviour
{

    public float sensivity = 100;
    public float loudness = 0;
    AudioSource _audio;

    void Start ()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = Microphone.Start("Built-in Microphone",true,10,44100);
        _audio.loop = true;
        _audio.mute = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        _audio.Play();

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

        void Update()
    {
        loudness = GetAveragedVolume() * sensivity;

        if (loudness >8)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 4);
        }
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data,0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
        }

        return a / 256;
    }
}