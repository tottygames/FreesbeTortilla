using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{

    public float speed = 1000; 
    void Start()
    {
        
    }

   
    void Update()
    {
      
      //  transform.Translate(-0.005f,0,0);

        if (transform.position.x > -540)
        {
          
            transform.position += new Vector3(-5, 0, 0) * speed* Time.deltaTime;
        }

        if (transform.position.x < -541)
        {
            
            transform.position = new Vector3(540, -824.88f, 0);

        }

    }
}
