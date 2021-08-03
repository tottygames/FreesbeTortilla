using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepper : MonoBehaviour
{


    public ScoreSystem scS;
    public int speed;
  
   
    void Update()
    {
        speed = Random.Range(1, 3);
        transform.position += new Vector3(-1,0,0)*Time.deltaTime*speed;
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        this.gameObject.SetActive(false);
    }


}
