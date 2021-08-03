using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TortillaMove>())
        {
            other.gameObject.GetComponent<TortillaMove>().health=-1;
        }


    }
}
