using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAud : MonoBehaviour
{
    // Start is called before the first frame update





    public GameObject audioInputObject;
    public float threshold = 1.0f;
    public GameObject objectToSpawn;
    Micro micIn;
    void Start()
    {
        if (objectToSpawn == null)
            Debug.LogError("You need to set a prefab to Object To Spawn -parameter in the editor!");
        if (audioInputObject == null)
            audioInputObject = GameObject.Find("AudioInputObject");
        micIn = (Micro)audioInputObject.GetComponent("MicrophoneInput");
    }
    void Update()
    {
        float l = micIn.loudness;
        if (l > threshold)
        {
            Vector3 scale = new Vector3(l, l, l);
            GameObject newObject = (GameObject)Instantiate(objectToSpawn, this.transform.position, Quaternion.identity);
            newObject.transform.localScale += scale;
        }


    }


}
