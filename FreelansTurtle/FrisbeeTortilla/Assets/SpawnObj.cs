using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    private static SpawnObj _instance;
    public static SpawnObj Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("The pool manager is equal NULL");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    [SerializeField]
    private GameObject[] ObstPrefabs;
    [SerializeField]
    private GameObject ObstConatiner;
    [SerializeField]
    private List<GameObject> ObstPool;
    [SerializeField]
    private TortillaMove TM;

    private void Start()
    {
        ObstPool = GenerateObj(10);
        StartCoroutine(SpawnCoroutine());
    }

    List<GameObject> GenerateObj(int bulletsAmount)
    {
        for (int i = 0; i < bulletsAmount; i++)
        {
            GameObject bullet = Instantiate(ObstPrefabs[0]);
            bullet.transform.parent = ObstConatiner.transform;
            bullet.SetActive(false);
            ObstPool.Add(bullet);
        } 
        for (int i = 0; i < bulletsAmount; i++)
        {
            GameObject bullet = Instantiate(ObstPrefabs[1]);
            bullet.transform.parent = ObstConatiner.transform;
            bullet.SetActive(false);
            ObstPool.Add(bullet);
        }

        return ObstPool;
    }

    public GameObject RequestObj()
    {
        for(int i = 0; i <  ObstPool.Count; i++)
        {
            int rand = Random.Range(0, ObstPool.Count);
            if (ObstPool[rand] == false)
            {
                ObstPool[rand].SetActive(true);
                return ObstPool[rand];
            }

        }

        GameObject newBullet = Instantiate(ObstPrefabs[Random.Range(0 , 2)]);
        newBullet.transform.parent = ObstConatiner.transform;
        ObstPool.Add(newBullet);
        return newBullet;
    }

    public void ClearMap()
    {
        foreach(var i in ObstPool)
        {
            i.SetActive(false);
        }
    }

    public void Restart()
    {
        StartCoroutine(SpawnCoroutine());
    }

   public IEnumerator SpawnCoroutine()
    {
        while (TM.gameOver == false)
        {
            RequestObj();
            yield return new WaitForSeconds(15);
        }
       
    }
}
