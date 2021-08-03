using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComet : MonoBehaviour
{
    public GameObject[] Obstacles;
    public DestroyUI ds;

    void Start()
    {
       // StartSpawnComet();
    }

    private IEnumerator RandomSpawn()
    {
        while (ds.gameOver == false)
        {

            Instantiate(Obstacles[Random.Range(0, 1)], new Vector3(Random.Range(0,8), -7, 1), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(20, 30));

        }

    }

    public void StartSpawnComet()
    {
        StartCoroutine(RandomSpawn());
    }
}
