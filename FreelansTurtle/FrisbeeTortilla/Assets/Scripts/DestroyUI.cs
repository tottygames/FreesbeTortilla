using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUI : MonoBehaviour
{
    [Header("Other Scripts")]
    public TortillaMove TM;
    public ScoreSystem SS;
    public SpawnComet sc;

    [Header("GameObjects")]
    public GameObject Turtle;
    public GameObject[] uiElements;
    public GameObject[] gameObjects;
    public GameObject gameOverUI;

    public bool gameOver = false;



    // Start is called before the first frame update
    void Start()
    {
        TM.health = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (TM.health <0)
        {
            Turtle.SetActive(false);
            foreach (var element in uiElements)
            {
                element.SetActive(false);
            }
            gameOverUI.SetActive(true);
            gameOver = true;
            StopScore();
            SpawnObj.Instance.ClearMap();
        }

    }

    public void StopScore()
    {
        SS.add = 0;
    }

    public void GoScore()
    {
       
       
        SS.add = 1;
    }

    public void Restart()
    {
        SS.scoreCounter = 0 ;
        Turtle.SetActive(true);
        TM.health = 1;
        TM.hasPowerup = false;
        GoScore();
        Turtle.transform.position= new Vector3(-1.6034443f, 1.5f,0);
        foreach (var element in uiElements)
        {
            element.SetActive(true);
        }
        gameOverUI.SetActive(false);
        gameOver = false;
        TM.StartScore();
        sc.StartSpawnComet();
        SpawnObj.Instance.Restart();
    }
}
