using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{

    private int speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(1, 4);
        transform.position += new Vector3(-1, 1.2f, 0) * Time.deltaTime * speed;
        //  transform.position += new Vector3(-1, 1.2f, 0) * Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, 0, 25);
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

}
